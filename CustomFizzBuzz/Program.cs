using TwistedFizzBuzzLibrary;
using TwistedFizzBuzzLibrary.Interface;

namespace TwistedFizzBuzzNamespace;

public class Program
{
	public static void Main()
	{
		ITwistedFizzBuzz fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();

		var customTokenMap = new Dictionary<string, int>
		{
			{ "Fizz", 5 },
			{ "Buzz", 9 },
			{ "Bar", 27 }
		};

		try
		{
			fizzBuzz.UpdateTokenMap(customTokenMap);

			var result = fizzBuzz.Execute(-20, 127);

			foreach (var res in result)
			{
				Console.WriteLine(res);
			}
		}
		catch(Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
