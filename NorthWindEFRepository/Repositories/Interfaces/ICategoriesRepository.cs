using NorthWindEFRepository.Entities;

namespace NorthWindEFRepository.Repositories
{
    public interface ICategoriesRepository : IBaseRepository<Category>, IPictureRepository
    {
        IAsyncEnumerable<Category> LookupByName(IList<string> names);
    }
}