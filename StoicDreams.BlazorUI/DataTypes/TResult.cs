using System.Diagnostics.CodeAnalysis;

namespace StoicDreams.BlazorUI.DataTypes;

public class TResult
{
	public TResultStatus Status { get; set; }
	public int StatusCode { get; set; }
	public string Message { get; set; } = string.Empty;
	public virtual bool IsOkay => Status == TResultStatus.Success;
}

public class TResult<T> : TResult
{
	public T? Result { get; set; }

	[MemberNotNullWhen(true, "Result")]
	public override bool IsOkay => base.IsOkay && Result != null;
}
