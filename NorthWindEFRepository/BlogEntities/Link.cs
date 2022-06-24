using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindEFRepository.BlogEntities
{
    public class Link
    {
        [Key]
        [Column("LinkID")]
        public int ID { get; set; }

        [Column("ArticleID")]
        public int ArticleId { get; set; }

        [Column("ProductID")]
        public int ProductId { get; set; }
    }
}
