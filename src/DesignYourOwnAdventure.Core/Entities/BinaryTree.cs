namespace DesignYourOwnAdventure.Core.Entities;

public record BinaryTree<T>
{
	public int BinaryTreeId { get; set; }
	public BinaryTreeNode<T>? Root { get; set; }
}