using NorthWindApi2.DTO;
using NorthWindEFRepository.Repositories;

namespace NorthWindApi2.Services
{
    /// <summary>
    /// Represents a management service for products.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository repository)
        {
            productRepository = repository;
        }

        /// <inheritdoc/>
        public async Task<int> CreateProduct(ProductRequest product)
        {
            return await productRepository.Add(product.ToEntity());
        }

        /// <inheritdoc/>
        public async Task DestroyProduct(int productId)
        {
            await productRepository.Remove(productId);
        }

        /// <inheritdoc/>
        public async Task<ProductResponse> Get(int productId)
        {
           return new ProductResponse(await productRepository.GetById(productId));
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<ProductResponse> GetCollection(int offset, int limit)
        {
            await foreach (var product in productRepository.GetCollection(offset, limit))
            {
                yield return new ProductResponse(product);
            }
        }

        /// <inheritdoc/>
        public async Task<int> GetCount() => await productRepository.GetCount();


        /// <inheritdoc/>
        public async IAsyncEnumerable<ProductRequest> LookupProductsByName(IList<string> names)
        {
            await foreach (var product in productRepository.LookupProductsByName(names))
            {
                yield return new ProductResponse(product);
            }
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<ProductRequest> ShowProductsForCategory(int categoryId)
        {
            await foreach (var product in productRepository.ShowProductsForCategory(categoryId))
            {
                yield return new ProductResponse(product);
            }
        }

        /// <inheritdoc/>
        public async Task UpdateProduct(int productId, ProductRequest product)
        {
            await productRepository.Update(productId, product.ToEntity());
        }
    }
}
