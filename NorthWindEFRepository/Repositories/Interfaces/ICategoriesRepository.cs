using NorthWindEFRepository.Entities;

namespace NorthWindEFRepository.Repositories
{
    public interface ICategoriesRepository : IBaseRepository<Category>
    {
        IAsyncEnumerable<Category> LookupByName(IList<string> names);
    }
}