using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzTokenAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokensController : ControllerBase
{
	[HttpGet]
	public IActionResult GetAPITokens()
	{
		var apiTokenDictionary = new Dictionary<string, int>
		{
			{ "Token1", 2 },
			{ "Token2", 6 },
			{ "Token3", 10 }
		};

		return Ok(apiTokenDictionary);
	}
}
