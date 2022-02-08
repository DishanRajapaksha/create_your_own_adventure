namespace DesignYourOwnAdventure.Core.Interfaces;

public interface IRepository<T>
{
	public Task<int> Create(T toCreate);
	public Task<T?> Read(int id);
	public Task<List<T>> Read();
}