using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Interfaces;
using DesignYourOwnAdventure.Core.Models;

namespace DesignYourOwnAdventure.Core.Services;

public class AdventureService : IAdventureService
{
	private readonly IRepository<BinaryTree<Question>> _adventureRepository;
	private readonly IRepository<Answer?> _answerRepository;
	private readonly IBinaryTreeService _binaryTreeService;

	public AdventureService(IBinaryTreeService binaryTreeService, IRepository<BinaryTree<Question>> adventureRepository,
		IRepository<Answer?> answerRepository)
	{
		_binaryTreeService = binaryTreeService;
		_adventureRepository = adventureRepository;
		_answerRepository = answerRepository;
	}
	
	public async Task<int> Create(CreateAdventureRequest request)
	{
		BinaryTree<Question> tree = _binaryTreeService.BuildTree(request);

		int result = await _adventureRepository.Create(tree);

		return result;
	}

	public async Task<List<BinaryTree<Question>>> Read()
	{
		List<BinaryTree<Question>> results = await _adventureRepository.Read();

		return results;
	}

	public async Task<BinaryTree<Question>?> Read(int id)
	{
		BinaryTree<Question>? result = await _adventureRepository.Read(id);

		return result;
	}
}