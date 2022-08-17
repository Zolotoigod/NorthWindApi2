using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace NorthWindEFRepository.BlogEntities
{
    public class Comment
    {
        [Key]
        [Column("comment_Id")]
        public int ID { get; set; }

        [Column("article_Id")]
        public int ArticleId { get; set; }

        [Column("comment")]
        public string Text { get; set; }

        [Column("created_Date")]

        public DateTime CreatedDate { get; set; }
    }
}
