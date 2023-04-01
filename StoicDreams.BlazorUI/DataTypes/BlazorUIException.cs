namespace StoicDreams.BlazorUI.DataTypes;

public class BlazorUIException<TType> : ApplicationException
{
	public BlazorUIException(string message, Exception? innerException = null) : base($"{typeof(TType).FullName} Exception: {message}", innerException) { }
}

public static class BlazorUIException
{
	public static void Throw<TType>(string message) => throw new BlazorUIException<TType>(message);

	public static void ReThrow<TException>(string message, TException innerException)
		 where TException : Exception
		=> throw new BlazorUIException<TException>($"{message} {innerException.Message}".Trim(), innerException);
}
