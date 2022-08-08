using NorthWindApi2.DTO;

namespace NorthWindApi2.Services
{
    public interface ICommentsService
    {
        Task<int> AddComment(int articleId, string text);

        IAsyncEnumerable<ArticleCommentResponse> GetAllComments(int articleId);

        Task UpdateComment(int commentId, string text);

        Task DeleteComment(int commentId);
    }
}
