using Markdig;

namespace StoicDreams.BlazorUI.Defaults;

public static partial class Setup
{
	public static IServiceCollection SetupMarkdownSupport(this IServiceCollection services)
	{
		services.AddTransient<IMarkdown, Data.Markdown>();
		services.AddTransient<MarkdownPipeline>(serviceProvider =>
		{
			// Configure the pipeline with all advanced extensions active
			return new MarkdownPipelineBuilder()
				.UseAdvancedExtensions()
				.UseEmojiAndSmiley()
				.Build()
				;
		});
		return services;
	}
}
