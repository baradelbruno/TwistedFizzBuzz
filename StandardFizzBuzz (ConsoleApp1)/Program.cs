using TwistedFizzBuzzLibrary;
using TwistedFizzBuzzLibrary.Interface;

namespace TwistedFizzBuzzNamespace;

public class Program
{
	public static void Main()
	{
		ITwistedFizzBuzz fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();

		var result = fizzBuzz.Execute(1, 100);

		foreach(var res in result)
		{
			Console.WriteLine(res);
		}
	}
}
