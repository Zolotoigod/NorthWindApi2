using NorthWindApi2.DTO;
using NorthWindEFRepository.Repositories;

namespace NorthWindApi2.Services
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository repository;
        private readonly IProductRepository productRepository;

        public LinkService(ILinkRepository repository, IProductRepository productRepository)
        {
            this.repository = repository;
            this.productRepository = productRepository;
        }

        public async Task<int> CreateLink(int articleId, int productId)
        {
            return await repository.CreateLink(articleId, productId);
        }

        // need tests
        public async IAsyncEnumerable<ProductResponse> GetRelatedProduct(int articleId)
        {
            await foreach (var link in repository.GetRelatedProduct(articleId))
            {
                yield return new ProductResponse(await productRepository.GetById(link.ProductId));
            }
        }

        public Task RemoveLink(int articleId, int productId)
        {
            return repository.RemoveLink(articleId, productId);
        }
    }
}
