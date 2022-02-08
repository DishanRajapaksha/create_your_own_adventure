using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Interfaces;
using DesignYourOwnAdventure.Core.Models;

namespace DesignYourOwnAdventure.Core.Services;

public class AnswerService: IAnswerService
{
	private readonly IRepository<BinaryTree<Question>> _adventureRepository;
	private readonly IRepository<Answer?> _answerRepository;
	private readonly IBinaryTreeService _binaryTreeService;

	public AnswerService(IBinaryTreeService binaryTreeService, IRepository<BinaryTree<Question>> adventureRepository,
		IRepository<Answer?> answerRepository)
	{
		_binaryTreeService = binaryTreeService;
		_adventureRepository = adventureRepository;
		_answerRepository = answerRepository;
	}
	
	public async Task<Answer?> Read(int answerId)
	{
		Answer? result = await _answerRepository.Read(answerId);

		return result;
	}

	public async Task<List<AnswerResponse>?> Traverse(int id)
	{
		Answer? answer = await _answerRepository.Read(id);

		if (answer == null) return null;

		BinaryTree<Question>? tree = await _adventureRepository.Read(answer.BinaryTreeId);

		if (tree == null) return null;

		List<AnswerResponse> path = _binaryTreeService.Traverse(tree, answer.Steps);

		return path;
	}

	public async Task<List<Answer?>> Read()
	{
		List<Answer?> result = await _answerRepository.Read();

		return result;
	}

	public async Task<int> Create(int userId, int adventureId, List<char> steps)
	{
		int result = await _answerRepository.Create(new Answer
		{
			Steps = steps,
			BinaryTreeId = adventureId,
			UserId = userId
		});

		return result;
	}
}