using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Interfaces;
using DesignYourOwnAdventure.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesignYourOwnAdventure.Infrastructure.Repositories;

public class AnswerRepository : IRepository<Answer>
{
	private readonly AdventureContext _adventureContext;
	private readonly ILogger<AdventureRepository> _logger;

	public AnswerRepository(ILogger<AdventureRepository> logger, AdventureContext adventureContext)
	{
		_logger = logger;
		_adventureContext = adventureContext;
	}

	public async Task<int> Create(Answer answer)
	{
		await _adventureContext.Answers.AddAsync(answer);

		int result = await _adventureContext.SaveChangesAsync();

		return result;
	}

	public async Task<Answer?> Read(int id)
	{
		Answer? answer = await _adventureContext.Answers.Where(x => x.AnswerId == id).FirstOrDefaultAsync();

		return answer;
	}

	public async Task<List<Answer>> Read()
	{
		List<Answer> answers = await _adventureContext.Answers.ToListAsync();

		return answers;
	}
}