namespace StoicDreams.BlazorUI.Data;

/// <summary>
/// Data storage mapped to specific pages.
/// Store data within this container that is shared within components within a given page, but do not carry over to other pages.
/// </summary>
public interface IPageState : IStateManager
{
}
