using NorthWindEFRepository.BlogEntities;

namespace NorthWindEFRepository.Repositories
{
    public interface ILinkRepository
    {
        /// <summary>
        /// Create link between article and product by id
        /// </summary>
        /// <param name="articleId">Article id</param>
        /// <param name="productId">Product Id</param>
        /// <returns>Link id</returns>
        Task<int> CreateLink(int articleId, int productId);

        /// <summary>
        /// Get Links by article id
        /// </summary>
        /// <param name="articleId">Article id</param>
        /// <returns>Links</returns>
        IAsyncEnumerable<Link> GetRelatedProduct(int articleId);

        /// <summary>
        /// Remove link between article and product by id
        /// </summary>
        /// <param name="articleId">Article id</param>
        /// <param name="productId">Product Id</param>
        Task RemoveLink(int articleId, int productId);
    }
}