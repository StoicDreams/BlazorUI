namespace StoicDreams.BlazorUI.Extensions;

public static class ExtendIAppState
{
	internal static void SetData<TData>(this IAppState appState, AppStateDataTags tag, TData? data) => appState.SetData(tag.ToString(), data);
	internal static TData? GetData<TData>(this IAppState appState, AppStateDataTags tag) => appState.GetData<TData>(tag.ToString());
}
