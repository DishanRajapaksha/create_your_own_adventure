using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace DesignYourOwnAdventure.Core.Services;

public class UserService: IUserService
{
	private readonly ILogger<IRepository<User>> _logger;
	private readonly IRepository<User> _userRepository;

	public UserService(ILogger<IRepository<User>> logger, IRepository<User> userRepository)
	{
		_logger = logger;
		_userRepository = userRepository;
	}
	
	public async Task<int> Create(User request)
	{
		int result = await _userRepository.Create(request);

		return result;
	}

	public async Task<List<User>> Read()
	{
		List<User> results = await _userRepository.Read();

		return results;
	}

	public async Task<User?> Read(int id)
	{
		User? result = await _userRepository.Read(id);

		return result;
	}
}