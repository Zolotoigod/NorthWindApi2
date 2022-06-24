using System.ComponentModel.DataAnnotations;

namespace NorthWindApi2.DTO
{
    public class ArticleRequest
    { 
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Text { get; set; }

        public DateTime PublishDate { get; set; }

        [Required]
        public int EmployeeId { get; set; }
    }
}
