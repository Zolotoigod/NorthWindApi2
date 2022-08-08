using NorthWindEFRepository.Entities;
using System.ComponentModel.DataAnnotations;

namespace NorthWindApi2.DTO
{
    public class ProductRequest
    {
        [Required]
        public string? ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }

        [Required]
        [StringLength(20)]
        public string? QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public Product ToEntity() => new Product()
        {
            Name = ProductName,
            SupplierId = SupplierId,
            CategoryId = CategoryId,
            QuantityPerUnit = QuantityPerUnit,
            UnitPrice = UnitPrice,
            UnitsInStock = UnitsInStock,
            UnitsOnOrder = UnitsOnOrder,
            ReorderLevel = ReorderLevel,
            Discontinued = Discontinued
        };        
    }
}
