using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoicDreams.BlazorUI.Data;

public class ApiRequest : IApiRequest
{
	public ApiRequest(HttpClient httpClient)
	{
		Client = httpClient;
	}

	public async ValueTask<TResult<T>> Get<T>(string url, bool isCacheable)
	{
		TResult<T> result = new();
		try
		{
			if (isCacheable && Cache.TryGetValue(url, out object? value))
			{
				result.Status = TResultStatus.Success;
				result.StatusCode = 200;
				result.Result = (T)value;
				return result;
			}
			HttpResponseMessage response = await Client.GetAsync(url);
			result.StatusCode = (int)response.StatusCode;
			result.Status = result.StatusCode switch
			{
				< 100 => TResultStatus.Exception,
				>= 100 and < 200 => TResultStatus.Info,
				>= 200 and < 300 => TResultStatus.Success,
				>= 300 and < 400 => TResultStatus.Redirect,
				>= 400 and < 500 => TResultStatus.ClientError,
				_ => TResultStatus.ServerError
			};
			string json = await response.Content.ReadAsStringAsync();
			result.Result = System.Text.Json.JsonSerializer.Deserialize<T>(json);
			if (result.Status == TResultStatus.Success && result.Result == null)
			{
				result.Status = TResultStatus.Exception;
				result.Message = "Incoming data did not match expected format.";
			}
		}
		catch(Exception ex)
		{
			result.Message = ex.Message;
		}
		return result;
	}

	private static Dictionary<string, object> Cache { get; } = new();

	private HttpClient Client { get; }
}
