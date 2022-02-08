using System.Text.Json.Serialization;

namespace DesignYourOwnAdventure.Core.Entities;

public record TreeNode<T>
{
	[JsonIgnore] 
	public List<TreeNode<T>>? Children { get; set; }

	public T? Data { get; set; }
}