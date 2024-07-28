using System.Net.Http.Json;
using System.Text;
using TwistedFizzBuzzLibrary.Interface;

namespace TwistedFizzBuzzLibrary;

internal class TwistedFizzBuzz : ITwistedFizzBuzz
{
	private Dictionary<string, int> TokenMap { get; set; } = new Dictionary<string, int>
	{
		{ "Fizz", 3 },
		{ "Buzz", 5 }
	};

	public List<string> Execute(int start, int end)
	{
		List<int> input = GenerateRange(start, end);
		return Execute(input);
	}

	public List<string> Execute(List<int> input)
	{
		List<string> convertedResults = [];

		foreach(var i in input)
		{
			StringBuilder result = new();

			foreach (var token in TokenMap)
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
		TokenMap = tokenMap;
	}

	public async Task GetAPIGeneratedTokens()
	{
		using HttpClient client = new();

		try
		{
			//TODO: Replace URL to https://rich-red-cocoon-veil.cyclic.app/ after API fix.
			Dictionary<string, int>? retrievedTokens = await client.GetFromJsonAsync<Dictionary<string, int>>("http://localhost:5150/api/MockToken");

			if (retrievedTokens is not null)
			{
				UpdateTokenMap(retrievedTokens);
			}
			else
			{
				throw new Exception("No data found.");
			}
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
