using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindEFRepository.BlogEntities
{
    public class Link
    {
        [Key]
        [Column("link_Id")]
        public int ID { get; set; }

        [Column("article_Id")]
        public int ArticleId { get; set; }

        [Column("product_Id")]
        public int ProductId { get; set; }
    }
}
