using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Interfaces;
using DesignYourOwnAdventure.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignYourOwnAdventure.Api.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class AdventureController : ControllerBase
{
	private readonly IAdventureService _adventureService;
	private readonly ILogger<AdventureController> _logger;

	public AdventureController(ILogger<AdventureController> logger, IAdventureService adventureService)
	{
		_logger = logger;
		_adventureService = adventureService;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		List<BinaryTree<Question>> results = await _adventureService.Read();

		return Ok(results);
	}
	
	[HttpGet("{adventureId:int}")]
	public async Task<IActionResult> Get(int adventureId)
	{
		BinaryTree<Question>? result = await _adventureService.Read(adventureId);

		return result == null ? NotFound() : Ok(result);
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateAdventureRequest request)
	{
		int result = await _adventureService.Create(request);

		return result == 1 ? NoContent() : Problem();
	}
}