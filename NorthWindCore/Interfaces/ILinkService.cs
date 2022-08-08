using NorthWindApi2.DTO;

namespace NorthWindApi2.Services
{
    public interface ILinkService
    {
        IAsyncEnumerable<ProductResponse> GetRelatedProduct(int articleId);

        Task<int> CreateLink(int articleId, int productId);

        Task RemoveLink(int articleId, int productId);
    }
}
