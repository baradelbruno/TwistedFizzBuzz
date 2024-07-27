using System.Text;

namespace TwistedFizzBuzzLibrary;

public class TwistedFizzBuzz
{
	private Dictionary<string, int> FizzBuzzMap { get; set; } = new Dictionary<string, int>
	{
		{ "Fizz", 3 },
		{ "Buzz", 5 }
	};

	public List<string> ConvertToFizzBuzz(int start, int end)
	{
		List<string> convertedResults = [];

		for (int i = start; i < end; i++)
		{
			StringBuilder result = new();

			foreach (var input in FizzBuzzMap)
			{
				if (i % input.Value == 0)
				{
					result.Append(input.Key);
				}
			}

			convertedResults.Add(result.Length > 0 ? result.ToString() : i.ToString());
		}

		return convertedResults;
	}

	public void UpdateFizzBuzzMap(Dictionary<string, int> fizzBuzzMap)
	{
		FizzBuzzMap = fizzBuzzMap;
	}
}
