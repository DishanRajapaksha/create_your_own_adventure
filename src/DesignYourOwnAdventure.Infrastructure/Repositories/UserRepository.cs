using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Interfaces;
using DesignYourOwnAdventure.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesignYourOwnAdventure.Infrastructure.Repositories;

public class UserRepository : IRepository<User>
{
	private readonly AdventureContext _adventureContext;
	private readonly ILogger<AdventureRepository> _logger;

	public UserRepository(ILogger<AdventureRepository> logger, AdventureContext adventureContext)
	{
		_logger = logger;
		_adventureContext = adventureContext;
	}

	public async Task<int> Create(User user)
	{
		await _adventureContext.Users.AddAsync(user);

		int result = await _adventureContext.SaveChangesAsync();

		return result;
	}

	public async Task<User?> Read(int id)
	{
		User? user = await _adventureContext.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();

		return user;
	}

	public async Task<List<User>> Read()
	{
		List<User> users = await _adventureContext.Users.ToListAsync();

		return users;
	}
}