using TwistedFizzBuzzLibrary;

namespace TwistedFizzBuzzNamespace;

public class Program
{
	public static void Main()
	{
		TwistedFizzBuzz fizzBuzz = new();

		var dict = new Dictionary<string, int>
		{
			{ "Fizz", 5 },
			{ "Buzz", 9 },
			{ "Bar", 27 }
		};

		fizzBuzz.UpdateFizzBuzzMap(dict);

		var result = fizzBuzz.ConvertToFizzBuzz(-20, 127);

		foreach (var res in result)
		{
			Console.WriteLine(res);
		}
	}
}
