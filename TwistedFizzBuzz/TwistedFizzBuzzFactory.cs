using TwistedFizzBuzzLibrary.Interface;

namespace TwistedFizzBuzzLibrary;

public static class TwistedFizzBuzzFactory
{
	public static ITwistedFizzBuzz CreateTwistedFizzBuzz(HttpClient? httpClient = null)
	{
		if (httpClient == null)
		{
			httpClient = new HttpClient()
			{
				BaseAddress = new Uri("http://localhost:5096")
			};
		}

		return new TwistedFizzBuzz(httpClient);
	}
}
