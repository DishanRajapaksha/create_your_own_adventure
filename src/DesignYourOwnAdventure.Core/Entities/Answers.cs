namespace DesignYourOwnAdventure.Core.Entities;

public class Answer
{
	public int AnswerId { get; set; }
	public int BinaryTreeId { get; set; }
	public int UserId { get; set; }
	public List<char> Steps { get; set; }
}