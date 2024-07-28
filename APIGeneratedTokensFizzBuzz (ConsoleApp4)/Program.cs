using TwistedFizzBuzzLibrary;
using TwistedFizzBuzzLibrary.Interface;

namespace TwistedFizzBuzzNamespace;

public class Program
{
	public static async Task Main()
	{
		ITwistedFizzBuzz fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();

		//Mocked API call to update token map
		await fizzBuzz.GetAPIGeneratedTokens();

		var result = fizzBuzz.Execute(-20, 127);

		foreach (var res in result)
		{
			Console.WriteLine(res);
		}
	}
}
