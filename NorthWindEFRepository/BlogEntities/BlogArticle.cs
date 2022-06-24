using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace NorthWindEFRepository.BlogEntities
{
    public class BlogArticle
    {
        [Key]
        [Column("ArticleID")]
        public int Id { get; set; }

        [Column("article_title")]
        public string Title { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("publish_date", TypeName = "datetime")]
        public DateTime PublishDate { get; set; }

        [Required]
        [Column("employee_id")]
        public int EmployeeId { get; set; }
    }
}
