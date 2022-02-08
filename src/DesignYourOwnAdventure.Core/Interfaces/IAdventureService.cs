using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Models;

namespace DesignYourOwnAdventure.Core.Interfaces;

public interface IAdventureService
{
	public Task<int> Create(CreateAdventureRequest request);
	public Task<List<BinaryTree<Question>>> Read();
	public Task<BinaryTree<Question>?> Read(int id);
}