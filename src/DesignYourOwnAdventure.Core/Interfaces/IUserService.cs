using DesignYourOwnAdventure.Core.Entities;

namespace DesignYourOwnAdventure.Core.Interfaces;

public interface IUserService
{
	public Task<List<User>> Read();
	public Task<User?> Read(int userId);
	Task<int> Create(User request);
}