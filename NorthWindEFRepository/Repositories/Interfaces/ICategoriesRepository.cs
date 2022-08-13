using NorthWindEFRepository.Entities;
using NorthWindEFRepository.Repositories.Interfaces;

namespace NorthWindEFRepository.Repositories
{
    public interface ICategoriesRepository : IBaseRepository<Category>, IPictureRepository
    {
        IAsyncEnumerable<Category> LookupByName(IList<string> names);
    }
}