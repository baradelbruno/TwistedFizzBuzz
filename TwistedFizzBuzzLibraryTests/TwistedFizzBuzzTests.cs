using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TwistedFizzBuzzLibrary;
using TwistedFizzBuzzLibrary.Interface;

namespace TwistedFizzBuzzLibraryTests;

public class TwistedFizzBuzzTests
{
	[Fact]
	[Trait("TwistedFizzBuzz", "Execute")]
	public void Execute_GivenStartAndEndNumbers_Success()
	{
		//Arrange
		ITwistedFizzBuzz _fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();
		int start = 1, end = 100;
		List<string> expectedResult =
		[
			"1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz",
			"11", "Fizz", "13", "14", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz",
			"Fizz", "22", "23", "Fizz", "Buzz", "26", "Fizz", "28", "29", "FizzBuzz",
			"31", "32", "Fizz", "34", "Buzz", "Fizz", "37", "38", "Fizz", "Buzz",
			"41", "Fizz", "43", "44", "FizzBuzz", "46", "47", "Fizz", "49", "Buzz",
			"Fizz", "52", "53", "Fizz", "Buzz", "56", "Fizz", "58", "59", "FizzBuzz",
			"61", "62", "Fizz", "64", "Buzz", "Fizz", "67", "68", "Fizz", "Buzz",
			"71", "Fizz", "73", "74", "FizzBuzz", "76", "77", "Fizz", "79", "Buzz",
			"Fizz", "82", "83", "Fizz", "Buzz", "86", "Fizz", "88", "89", "FizzBuzz",
			"91", "92", "Fizz", "94", "Buzz", "Fizz", "97", "98", "Fizz", "Buzz"
		];

		//Act
		var result = _fizzBuzz.Execute(start, end);

		//Assert
		Assert.NotEmpty(result);
		Assert.DoesNotContain("", result);
		Assert.Equal(100, result.Count);
		Assert.Equal(expectedResult, result);
	}

	[Fact]
	[Trait("TwistedFizzBuzz", "Execute")]
	public void Execute_GivenSameStartAndEndNumbers_Success()
	{
		//Arrange
		ITwistedFizzBuzz _fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();
		int start = 1, end = 1;
		List<string> expectedResult = [ "1" ];

		//Act
		var result = _fizzBuzz.Execute(start, end);

		//Assert
		Assert.NotEmpty(result);
		Assert.DoesNotContain("", result);
		Assert.Single(result);
		Assert.Equal(expectedResult, result);
	}

	[Fact]
	[Trait("TwistedFizzBuzz", "Execute")]
	public void Execute_GivenNonSequentialInput_Success()
	{
		//Arrange
		ITwistedFizzBuzz _fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();
		List<int> NonSequentialInput = [-5, 6, 300, 12, 25];
		List<string> expectedResult = [ "Buzz", "Fizz", "FizzBuzz", "Fizz","Buzz" ];

		//Act
		var result = _fizzBuzz.Execute(NonSequentialInput);

		//Assert
		Assert.NotEmpty(result);
		Assert.DoesNotContain("", result);
		Assert.Equal(5, result.Count);
		Assert.Equal(expectedResult, result);
	}

	[Fact]
	[Trait("TwistedFizzBuzz", "Execute")]
	public void Execute_GivenEmptyList_ReturnEmptyResult()
	{
		//Arrange
		ITwistedFizzBuzz _fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();
		List<int> emptyList = [];

		//Act
		var result = _fizzBuzz.Execute(emptyList);

		//Assert
		Assert.Empty(result);
	}

	[Fact]
	[Trait("TwistedFizzBuzz", "UpdateTokenMap")]
	public void UpdateTokenMap_GivenValidInput_UpdateTokenMapSuccessfully()
	{
		//Arrange
		ITwistedFizzBuzz _fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();
		var newTokenMap = new Dictionary<string, int>
		{
			{ "token1", 2 },
			{ "token2", 4 }
		};

		//Act
		_fizzBuzz.UpdateTokenMap(newTokenMap);

		//Assert
		Assert.Equal(newTokenMap, _fizzBuzz.GetTokenMap());
	}

	[Fact]
	[Trait("TwistedFizzBuzz", "UpdateTokenMap")]
	public void UpdateTokenMap_GivenEmptyInput_ThrowException()
	{
		//Arrange
		ITwistedFizzBuzz _fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();

		//Act & Assert
		Assert.Throws<ArgumentException>(() => _fizzBuzz.UpdateTokenMap(null!));
	}

	[Fact]
	[Trait("TwistedFizzBuzz", "UpdateTokenMap")]
	public void UpdateTokenMap_GivenZeroAsDivisor_ThrowException()
	{
		//Arrange
		ITwistedFizzBuzz _fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz();
		var newTokenMap = new Dictionary<string, int>
		{
			{ "token1", 0 },
			{ "token2", 4 }
		};

		//Act & Assert
		Assert.Throws<ArgumentException>(() => _fizzBuzz.UpdateTokenMap(newTokenMap));
	}

	[Fact]
	[Trait("TwistedFizzBuzz", "UpdateTokenMapWithAPIGeneratedData")]
	public async Task UpdateTokenMapWithAPIGeneratedData_SuccessfullyUpdatesTokenMap()
	{
		// Arrange
		var mockTokens = new Dictionary<string, int> { 
			{ "token1", 1 }, 
			{ "token2", 2 } 
		};

		var mockHandler = new Mock<HttpMessageHandler>();

		mockHandler
			.Protected()
			.Setup<Task<HttpResponseMessage>>(
				"SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>()
			)
			.ReturnsAsync(new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.OK,
				Content = new StringContent("{\"token1\": 1, \"token2\": 2}")
				{
					Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
				}
			});

		var httpClient = new HttpClient(mockHandler.Object)
		{
			BaseAddress = new Uri("http://localhost:5096")
		};

		ITwistedFizzBuzz fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz(httpClient);

		// Act
		await fizzBuzz.UpdateTokenMapWithAPIGeneratedData();

		// Assert
		Assert.Equal(mockTokens, fizzBuzz.GetTokenMap());

	}

	[Fact]
	[Trait("TwistedFizzBuzz", "UpdateTokenMapWithAPIGeneratedData")]
	public async Task UpdateTokenMapWithAPIGeneratedData_ThrowsException_WhenAPIReturnsNoData()
	{
		// Arrange
		var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
		{
			Content = JsonContent.Create(new Dictionary<string, int>())
		};

		var mockHandler = new Mock<HttpMessageHandler>();

		mockHandler
			.Protected()
			.Setup<Task<HttpResponseMessage>>(
				"SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>()
			)
			.ReturnsAsync(mockResponse);

		var httpClient = new HttpClient(mockHandler.Object)
		{
			BaseAddress = new Uri("http://localhost:5096")
		};

		ITwistedFizzBuzz fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz(httpClient);

		// Act & Assert
		await Assert.ThrowsAsync<Exception>(() => fizzBuzz.UpdateTokenMapWithAPIGeneratedData());
	}

	[Fact]
	[Trait("TwistedFizzBuzz", "UpdateTokenMapWithAPIGeneratedData")]
	public async Task UpdateTokenMapWithAPIGeneratedData_ThrowsException_WhenHttpRequestFails()
	{
		// Arrange
		var mockResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);

		var mockHandler = new Mock<HttpMessageHandler>();

		mockHandler
			.Protected()
			.Setup<Task<HttpResponseMessage>>(
				"SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>()
			)
			.ReturnsAsync(mockResponse);

		var httpClient = new HttpClient(mockHandler.Object)
		{
			BaseAddress = new Uri("http://localhost:5096")
		};

		ITwistedFizzBuzz fizzBuzz = TwistedFizzBuzzFactory.CreateTwistedFizzBuzz(httpClient);

		// Act & Assert
		await Assert.ThrowsAsync<HttpRequestException>(() => fizzBuzz.UpdateTokenMapWithAPIGeneratedData());
	}
}