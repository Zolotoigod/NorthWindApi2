using NorthWindEFRepository.Entities;

namespace NorthWindEFRepository.Repositories
{
    public interface ICategoriesRepository
    {
        Task<int> Add(Category category);
        Task<Category> GetById(int categoryId);
        IAsyncEnumerable<Category> GetCollection(int offset, int limit);
        Task Remove(int categoryId);
        Task Update(int categoryId, Category newCategory);

        Task<int> GetCount();
    }
}