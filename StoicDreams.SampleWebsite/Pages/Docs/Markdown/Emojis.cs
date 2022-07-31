using StoicDreams.BlazorUI.DataTypes;
using System.Text;

namespace StoicDreams.SampleWebsite.Pages.Docs.Markdown;

[Route("/docs/markdown/emojis")]
public class Emojis : BUIPage
{
	[Inject] private HttpClient? Client { get; set; }
	[Inject] private ISnackbar? SnackBar { get; set; }
	[Inject] private IApiRequest? ApiRequest { get; set; }

	[MemberNotNull(nameof(Client), nameof(SnackBar), nameof(ApiRequest))]
	private void ValidateInjection()
	{
		if (Client == null) { throw new NullReferenceException("Failed to inject HttpClient."); }
		if (SnackBar == null) { throw new NullReferenceException("Failed to inject ISnackbar."); }
		if (ApiRequest == null) { throw new NullReferenceException("Failed to inject IApiRequest."); }
	}

	protected override ValueTask InitializePage()
	{
		Title = "Markdown Emojis";
		UpdatePageContent();
		return ValueTask.CompletedTask;
	}

	private void UpdatePageContent()
	{
		FlipState = !FlipState;
		ValidateInjection();
		if (CachedList == null)
		{
			SetPageContent(
				PageIntroduction,
				Skeleton(SkeletonType.Rectangle, "100%", "800px")
				);
			SnackBar.Add($"Init Page Content.", Severity.Info);
			_ = LoadEmojies();
			return;
		}
		else
		{
			return;
			SetPageContent(
				PageIntroduction,
				Paper(PaperTypes.Wrap, "emoji-tables gap-4")
					.AddChild(Virtualize(CachedList, item =>
						Paper(PaperTypes.None, "center")
							.AddChild(MarkdownSection(item))
						)
					)
				);
		}
	}

	private PageSegment PageIntroduction => MarkdownSection("## Our Markdown supports Emojis :wink:!");

	private async Task LoadEmojies()
	{
		ValidateInjection();
		SetState(AppStateDataTags.IsLoadingPage, true);
		TResult<string[]> result = await ApiRequest.Get<string[]>("https://www.myfi.ws/bui/emojis.json", true);
		if (!result.IsOkay)
		{
			SnackBar.Add($"Failed to load emojis. {result.Message}", Severity.Error);
			SetState(AppStateDataTags.IsLoadingPage, false);
			return;
		}
		SnackBar.Add($"Emojis Loaded.", Severity.Info);
		CachedList = BuildMarkdownList(result.Result);
		SnackBar.Add($"Cache set.", Severity.Info);
		SetState(AppStateDataTags.IsLoadingPage, false);
		UpdatePageContent();
	}

	private static List<string>? CachedList { get; set; }

	private static List<string> BuildMarkdownList(string[] inputList)
	{
		List<string> list = new();
		int maxColumnCount = 3, maxRowCount = 10;
		StringBuilder markup = new(), rowEmoji = new(), rowText = new();
		string[] header = new string[maxColumnCount];
		Array.Fill(header, "     ");
		markup.AppendLine($"|{string.Join('|', header)}|");
		Array.Fill(header, " --- ");
		markup.AppendLine($"|{string.Join('|', header)}|");
		rowEmoji.Append("|");
		rowText.Append("|");
		for (int index = 0, col = 0, row = 0; index < inputList.Length; ++index)
		{
			rowEmoji.Append($" {inputList[index]} |");
			rowText.Append($" `{inputList[index]}` |");
			++col;
			if (col >= maxColumnCount)
			{
				col = 0;
				markup.AppendLine(rowEmoji.ToString());
				markup.AppendLine(rowText.ToString());
				rowEmoji.Clear();
				rowText.Clear();
				++row;
				if (row >= maxRowCount)
				{
					row = 0;
					list.Add(markup.ToString());
					markup.Clear();
					Array.Fill(header, "     ");
					markup.AppendLine($"|{string.Join('|', header)}|");
					Array.Fill(header, " --- ");
					markup.AppendLine($"|{string.Join('|', header)}|");
				}
				rowEmoji.Append("|");
				rowText.Append("|");
			}
		}
		markup.AppendLine(rowEmoji.ToString());
		markup.AppendLine(rowText.ToString());
		markup.AppendLine("");
		list.Add(markup.ToString());
		return list;
	}
}
