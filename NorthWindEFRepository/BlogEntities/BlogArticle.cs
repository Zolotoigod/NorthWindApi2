using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace NorthWindEFRepository.BlogEntities
{
    public class BlogArticle
    {
        [Key]
        [Column("article_Id")]
        public int Id { get; set; }

        [Column("article_Title")]
        public string Title { get; set; }

        [Column("article_Text")]
        public string Text { get; set; }

        [Column("publish_Date", TypeName = "datetime")]
        public DateTime PublishDate { get; set; }

        [Required]
        [Column("employee_Id")]
        public int EmployeeId { get; set; }
    }
}
