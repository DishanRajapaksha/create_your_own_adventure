using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Models;

namespace DesignYourOwnAdventure.Core.Interfaces;

public interface IAnswerService
{
	public Task<int> Create(int userId, int adventureId, List<char> steps);
	public Task<List<Answer?>> Read();
	public Task<Answer?> Read(int answerId);
	public Task<List<AnswerResponse>> Traverse(int id);
}