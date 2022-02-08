using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Interfaces;
using DesignYourOwnAdventure.Core.Models;

namespace DesignYourOwnAdventure.Core.Services;

public class BinaryTreeService : IBinaryTreeService
{
	public BinaryTree<Question> BuildTree(CreateAdventureRequest request)
	{
		BinaryTree<Question> tree = new();

		if (string.IsNullOrWhiteSpace(request.Question)) return tree;

		tree.Root = new BinaryTreeNode<Question>
		{
			Data = new Question(request.Question)
		};

		BuildLeaf(tree.Root, request);

		return tree;
	}

	public List<AnswerResponse> Traverse(BinaryTree<Question> tree, List<char> steps)
	{
		List<AnswerResponse> answers = new();

		BinaryTreeNode<Question>? root = tree.Root;

		foreach (char step in steps)
		{
			answers.Add(new AnswerResponse
			{
				Answer = step,
				Question = root?.Data?.Text
			});

			root = step switch
			{
				'L' => root?.Left,
				'R' => root?.Right,
				_ => root
			};
		}

		return answers;
	}

	private void BuildLeaf(BinaryTreeNode<Question>? root, CreateAdventureRequest? request)
	{
		if (root == null)
		{
			return;
		}

		if (!string.IsNullOrWhiteSpace(request?.Left?.Question))
		{
			root.Left ??= new BinaryTreeNode<Question>
			{
				Data = new Question(request.Left.Question)
			};
			BuildLeaf(root.Left, request.Left);
		}

		if (!string.IsNullOrWhiteSpace(request?.Right?.Question))
		{
			root.Right ??= new BinaryTreeNode<Question>
			{
				Data = new Question(request.Right.Question)
			};
			BuildLeaf(root.Right, request.Right);
		}
	}
}