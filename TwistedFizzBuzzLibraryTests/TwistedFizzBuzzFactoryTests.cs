using TwistedFizzBuzzLibrary.Interface;
using TwistedFizzBuzzLibrary;

namespace TwistedFizzBuzzLibraryTests;

public class TwistedFizzBuzzFactoryTests
{
	private readonly HttpClient _httpClient;

	public TwistedFizzBuzzFactoryTests()
	{
		_httpClient = new HttpClient();
	}

	[Fact]
	[Trait("TwistedFizzBuzzFactory", "CreateTwistedFizzBuzz")]
	public void CreateTwistedFizzBuzz_ShouldReturnInstanceSuccessfully()
	{
		// Arrange & Act
		var result = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz(_httpClient);

		// Assert
		Assert.NotNull(result);
		Assert.IsAssignableFrom<ITwistedFizzBuzz>(result);
	}

	[Fact]
	public void CreateTwistedFizzBuzz_ShouldReturnDifferentInstances()
	{
		// Arrange & Act
		var instance1 = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz(_httpClient);
		var instance2 = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz(_httpClient);

		// Assert
		Assert.NotSame(instance1, instance2);
	}
}
