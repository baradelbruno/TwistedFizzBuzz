using TwistedFizzBuzzLibrary.Interface;
using TwistedFizzBuzzLibrary;

namespace TwistedFizzBuzzLibraryTests;

public class TwistedFizzBuzzFactoryTests
{

	[Fact]
	[Trait("TwistedFizzBuzzFactory", "CreateTwistedFizzBuzz")]
	public void CreateTwistedFizzBuzz_ShouldReturnInstanceSuccessfully()
	{
		// Arrange & Act
		var result = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();

		// Assert
		Assert.NotNull(result);
		Assert.IsAssignableFrom<ITwistedFizzBuzz>(result);
	}

	[Fact]
	[Trait("TwistedFizzBuzzFactory", "CreateTwistedFizzBuzz")]
	public void CreateTwistedFizzBuzz_ShouldReturnDifferentInstances()
	{
		// Arrange & Act
		var instance1 = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();
		var instance2 = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();

		// Assert
		Assert.NotSame(instance1, instance2);
	}
}
