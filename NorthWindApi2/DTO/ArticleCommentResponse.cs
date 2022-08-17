using NorthWindEFRepository.BlogEntities;
using System.ComponentModel.DataAnnotations;

namespace NorthWindApi2.DTO
{
    public class ArticleCommentResponse
    {
        public ArticleCommentResponse(Comment comment)
        {
            Id = comment.ID;
            ArticleId = comment.ArticleId;
            Text = comment.Text;
            CreatedDate = comment.CreatedDate;
        }

        public int Id { get; set; }

        public int ArticleId { get; set; }

        [Required]
        public string? Text { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}