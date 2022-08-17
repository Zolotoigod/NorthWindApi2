using NorthWindApi2.DTO;
using NorthWindEFRepository.Repositories;

namespace NorthWindApi2.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentRepository repository;

        public CommentsService(ICommentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddComment(int articleId, string text)
        {
            return await repository.AddComment(articleId, text);
        }

        public async Task DeleteComment(int commentId)
        {
            await repository.DeleteComment(commentId);
        }

        public async IAsyncEnumerable<ArticleCommentResponse> GetAllComments(int articleId)
        {
            await foreach (var comment in repository.GetAllComments(articleId))
            {
                yield return new ArticleCommentResponse(comment);
            }
        }

        public async Task UpdateComment(int commentId, string text)
        {
            await repository.UpdateComment(commentId, text);
        }
    }
}
