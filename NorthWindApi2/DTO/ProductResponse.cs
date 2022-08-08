using NorthWindEFRepository.Entities;

namespace NorthWindApi2.DTO
{
    public class ProductResponse : ProductRequest
    {
        public ProductResponse(Product product)
        {
            ProductId = product.Id;
            ProductName = product.Name;
            CategoryId = product.CategoryId;
            ReorderLevel = product.ReorderLevel;
            SupplierId = product.SupplierId;
            UnitPrice = product.UnitPrice;
            UnitsInStock = product.UnitsInStock;
            UnitsOnOrder = product.UnitsOnOrder;
            QuantityPerUnit = product.QuantityPerUnit;
            Discontinued = product.Discontinued;
        }

        public int ProductId { get; set; }
    }
}
