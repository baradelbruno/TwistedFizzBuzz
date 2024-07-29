using TwistedFizzBuzzLibrary;
using TwistedFizzBuzzLibrary.Interface;

namespace TwistedFizzBuzzNamespace;

public class Program
{
	public static void Main()
	{
		ITwistedFizzBuzz fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();

		List<int> nonSequentialInput = [-5, 6, 300, 12, 25];
		var result = fizzBuzz.Execute(nonSequentialInput);

		foreach (var res in result)
		{
			Console.WriteLine(res);
		}
	}
}


