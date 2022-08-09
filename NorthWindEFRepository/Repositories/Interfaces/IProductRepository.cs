using NorthWindEFRepository.Entities;

namespace NorthWindEFRepository.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IAsyncEnumerable<Product> LookupProductsByName(IList<string> names);
        IAsyncEnumerable<Product> ShowProductsForCategory(int categoryId);
    }
}