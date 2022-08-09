namespace NorthWindEFRepository.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<int> Add(T obj);
        Task<T> GetById(int objectId);
        IAsyncEnumerable<T> GetCollection(int offset, int limit);
        Task Remove(int obj);
        Task Update(int obj, T newObj);
        Task<int> GetCount();
    }
}