using TwistedFizzBuzzLibrary;

namespace TwistedFizzBuzzNamespace;

public class Program
{
	public static void Main()
	{
		TwistedFizzBuzz fizzBuzz = new();
		var result = fizzBuzz.ConvertToFizzBuzz(1, 100);

		foreach(var res in result)
		{
			Console.WriteLine(res);
		}
	}
}
