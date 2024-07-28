using TwistedFizzBuzzLibrary;
using TwistedFizzBuzzLibrary.Interface;

namespace TwistedFizzBuzzNamespace;

public class Program
{
	public static void Main()
	{
		ITwistedFizzBuzz fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();

		List<int> ints = [-5, 6, 300, 12, 25];
		var result = fizzBuzz.Execute(ints);

		foreach (var res in result)
		{
			Console.WriteLine(res);
		}
	}
}


