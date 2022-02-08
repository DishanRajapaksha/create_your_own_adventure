using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesignYourOwnAdventure.Api.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly ILogger<UserController> _logger;

	public UserController(ILogger<UserController> logger, IUserService userService)
	{
		_logger = logger;
		_userService = userService;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		List<User> results = await _userService.Read();

		return Ok(results);
	}
	
	[HttpGet("{userId:int}")]
	public async Task<IActionResult> Get(int userId)
	{
		User? result = await _userService.Read(userId);

		return result == null ? NotFound() : Ok(result);
	}

	[HttpPost]
	public async Task<IActionResult> Create(User request)
	{
		int result = await _userService.Create(request);

		return result == 1 ? NoContent() : Problem();
	}
}