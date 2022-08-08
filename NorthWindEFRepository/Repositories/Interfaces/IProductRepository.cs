using NorthWindEFRepository.Entities;

namespace NorthWindEFRepository.Repositories
{
    public interface IProductRepository
    {
        Task<int> Add(Product product);
        Task<Product> GetById(int productId);
        IAsyncEnumerable<Product> GetCollection(int offset, int limit);
        Task Remove(int productId);
        Task Update(int productId, Product newProduct);
        Task<int> GetCount();
        IAsyncEnumerable<Product> LookupProductsByName(IList<string> names);
        IAsyncEnumerable<Product> ShowProductsForCategory(int categoryId);
    }
}