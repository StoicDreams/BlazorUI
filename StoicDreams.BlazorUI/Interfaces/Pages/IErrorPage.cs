namespace StoicDreams.BlazorUI.Interfaces.Pages;

public interface IErrorPage
{
	string ErrorMessage { get; set; }
	Exception? Exception { get; set; }
}
