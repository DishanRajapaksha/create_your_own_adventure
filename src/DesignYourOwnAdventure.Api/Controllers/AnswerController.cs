using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Interfaces;
using DesignYourOwnAdventure.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignYourOwnAdventure.Api.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class AnswerController : ControllerBase
{
	private readonly IAnswerService _answerService;
	private readonly ILogger<AnswerController> _logger;

	public AnswerController(ILogger<AnswerController> logger, IAnswerService answerService)
	{
		_logger = logger;
		_answerService = answerService;
	}

	[HttpGet("{answerId:int}")]
	public async Task<IActionResult> Get(int answerId)
	{
		Answer? results = await _answerService.Read(answerId);

		return Ok(results);
	}
	
	[HttpGet]
	public async Task<IActionResult> Get()
	{
		List<Answer?> results = await _answerService.Read();

		return Ok(results);
	}

	[HttpPost]
	public async Task<IActionResult> Create(int userId, int adventureId, List<char> steps)
	{
		int result = await _answerService.Create(userId, adventureId, steps);

		return result == 1 ? NoContent() : Problem();
	}
	
	[HttpGet("Traverse")]
	public async Task<IActionResult> Traverse(int id)
	{
		List<AnswerResponse> results = await _answerService.Traverse(id);

		return Ok(results);
	}
}