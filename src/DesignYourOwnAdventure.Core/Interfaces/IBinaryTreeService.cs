using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Models;

namespace DesignYourOwnAdventure.Core.Interfaces;

public interface IBinaryTreeService
{
	public BinaryTree<Question> BuildTree(CreateAdventureRequest request);
	public List<AnswerResponse> Traverse(BinaryTree<Question> tree, List<char> steps);
}