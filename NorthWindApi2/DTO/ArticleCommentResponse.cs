using System.ComponentModel.DataAnnotations;

namespace NorthWindApi2.DTO
{
    public class ArticleCommentResponse
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        [Required]
        public string? Text { get; set; }
    }
}