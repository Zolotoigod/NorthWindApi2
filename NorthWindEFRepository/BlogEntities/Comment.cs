using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace NorthWindEFRepository.BlogEntities
{
    public class Comment
    {
        [Key]
        [Column("CommentID")]
        public int ID { get; set; }

        [Column("ArticleId")]
        public int ArticleId { get; set; }

        [Column("Comment")]
        public string Text { get; set; }

        [Column("CreatedDate")]

        public DateTime CreatedDate { get; set; }
    }
}
