using Microsoft.EntityFrameworkCore;
using NorthWindEFRepository.BlogEntities;
using NorthWindEFRepository.Contexts;

namespace NorthWindEFRepository.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BloggingContext context;

        public CommentRepository(BloggingContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<int> AddComment(int articleId, string text)
        {
            var comment = new Comment { ArticleId = articleId, Text = text };
            await context.Comments!.AddAsync(comment);
            await context.SaveChangesAsync();
            return comment.ID;
        }

        /// <inheritdoc/>
        public async Task DeleteComment(int commentId)
        {
            var comment = await context.Comments!.FindAsync(commentId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Comment,
                    commentId));
            context.Comments!.Remove(comment);
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<Comment> GetAllComments(int articleId)
        {
            var query = context.Comments!
                .Where(c => c.ArticleId == articleId)
                .OrderByDescending(c => c.CreatedDate)
                .AsAsyncEnumerable();
            await foreach (var category in query)
            {
                yield return category;
            }
        }

        /// <inheritdoc/>
        public async Task UpdateComment(int commentId, string text)
        {
            var comment = await context.Comments!.FindAsync(commentId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Comment,
                    commentId));
            comment.Text = text ?? comment.Text;

            await context.SaveChangesAsync();
        }
    }
}
