using NorthWindEFRepository.BlogEntities;
using NorthWindEFRepository.Entities;

namespace NorthWindEFRepository.Repositories
{
    public interface IBloggingRepository : IBaseRepository<BlogArticle>
    {
    }
}