namespace DesignYourOwnAdventure.Core.Models;

public record CreateAdventureRequest
{
	public string? Question { get; set; }
	public CreateAdventureRequest? Left { get; set; }
	public CreateAdventureRequest? Right { get; set; }
}