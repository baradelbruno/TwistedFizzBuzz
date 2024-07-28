using TwistedFizzBuzzLibrary.Interface;

namespace TwistedFizzBuzzLibrary;

public static class TwistedFizzBuzzFactory
{
	public static ITwistedFizzBuzz CreateTwistedFizzBuzz()
	{
		return new TwistedFizzBuzz();
	}
}
