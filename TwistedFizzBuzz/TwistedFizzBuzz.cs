using System.Net.Http.Json;
using System.Text;
using TwistedFizzBuzzLibrary.Interface;

namespace TwistedFizzBuzzLibrary;

internal class TwistedFizzBuzz(HttpClient httpClient) : ITwistedFizzBuzz
{

	private readonly HttpClient _httpClient = httpClient;
	private readonly Dictionary<string, int> _tokenMap = new()
	{
		{ "Fizz", 3 },
		{ "Buzz", 5 }
	};

	public List<string> Execute(int start, int end)
	{
		List<int> input = GenerateRange(start, end);
		return Execute(input);
	}

	public List<string> Execute(List<int> inputList)
	{
		List<string> convertedResults = [];

		foreach(var i in inputList)
		{
			StringBuilder result = new();

			foreach (var token in _tokenMap)
			{
				if (i % token.Value == 0)
				{
					result.Append(token.Key);
				}
			}

			convertedResults.Add(result.Length > 0 ? result.ToString() : i.ToString());
		}

		return convertedResults;
	}

	public void UpdateTokenMap(Dictionary<string, int> tokenMap)
	{
		if (tokenMap is null || tokenMap.Count == 0)
		{
			throw new ArgumentException("Token map cannot be null or empty.");
		}

		foreach (var token in tokenMap)
		{
			if (token.Value == 0)
			{
				throw new ArgumentException($"Token value cannot be zero.");
			}
		}

		_tokenMap.Clear();
		foreach (var item in tokenMap)
		{
			_tokenMap[item.Key] = item.Value;
		}
	}

	public IReadOnlyDictionary<string, int> GetTokenMap()
	{
		return _tokenMap;
	}

	public async Task UpdateTokenMapWithAPIGeneratedData()
	{
		try
		{
			Dictionary<string, int>? retrievedTokens = await GetAPITokensAsync();
			UpdateTokenMap(retrievedTokens);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error updating token map with API Generated Data: {ex.Message}");
			throw;
		}
	}

	private async Task<Dictionary<string, int>> GetAPITokensAsync()
	{
		try
		{
			//Calling my own API since the given API is not accessible. You can find the API implementation at API/FizzBuzzTokenAPI.
			Dictionary<string, int>? retrievedTokens = await _httpClient.GetFromJsonAsync<Dictionary<string, int>>("http://localhost:5096/api/Tokens");

			if (retrievedTokens is not null && retrievedTokens.Count > 0)
			{
				return retrievedTokens;
			}

			throw new Exception("No data found.");
		}
		
		catch (HttpRequestException e)
		{
			Console.WriteLine($"Request error: {e.Message}");
			throw;
		}
		catch (NotSupportedException e)
		{
			Console.WriteLine($"Content not supported: {e.Message}");
			throw;
		}
		catch (Exception e)
		{
			Console.WriteLine($"Unexpected Error: {e.Message}");
			throw;
		}
	}

	private static List<int> GenerateRange(int start, int end)
	{
		List<int> result = [];

		if (start <= end)
		{
			for (int i = start; i <= end; i++)
			{
				result.Add(i);
			}
		}
		else
		{
			for (int i = start; i >= end; i--)
			{
				result.Add(i);
			}
		}

		return result;
	}
}
