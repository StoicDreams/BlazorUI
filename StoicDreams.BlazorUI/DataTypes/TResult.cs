namespace StoicDreams.BlazorUI.DataTypes;

public class TResult
{
	public TResultStatus Status { get; set; }
	public int StatusCode { get; set; }
	public string Message { get; set; } = string.Empty;
}

public class TResult<T> : TResult
{
	public T? Result { get; set; }
}
