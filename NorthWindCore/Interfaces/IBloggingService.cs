using NorthWindApi2.DTO;

namespace NorthWindApi2.Services
{
    public interface IBloggingService
    {
        Task<int> Create(ArticleRequest article);

        Task Update(int articleId, ArticleRequest article);

        Task Delete(int articleId);

        Task<ArticleResponse> FindById(int articleId);

        IAsyncEnumerable<ArticleResponse> FindAll(int offset, int limit);
    }
}
