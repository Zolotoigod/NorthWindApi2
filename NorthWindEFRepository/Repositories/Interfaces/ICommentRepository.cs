using NorthWindEFRepository.BlogEntities;

namespace NorthWindEFRepository.Repositories
{
    public interface ICommentRepository
    {
        /// <summary>
        /// Create comment
        /// </summary>
        /// <param name="articleId">Article id</param>
        /// <param name="text">Comment text</param>
        /// <returns>Comments id</returns>
        Task<int> AddComment(int articleId, string text);

        /// <summary>
        /// Remove comment
        /// </summary>
        /// <param name="commentId">Commment id</param>
        Task DeleteComment(int commentId);

        /// <summary>
        /// Get article`s comments
        /// </summary>
        /// <param name="articleId">article id</param>
        /// <returns>Comments</returns>
        IAsyncEnumerable<Comment> GetAllComments(int articleId);

        /// <summary>
        /// Update comment
        /// </summary>
        /// <param name="commentId">Comment Id</param>
        /// <param name="text">new text</param>
        Task UpdateComment(int commentId, string text);
    }
}