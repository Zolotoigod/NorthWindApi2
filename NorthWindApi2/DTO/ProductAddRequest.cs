using NorthWindEFRepository.Entities;
using System.ComponentModel.DataAnnotations;

namespace NorthWindApi2.DTO
{
    // TODO use it for solve nullable problems
    public class ProductAddRequest : ProductRequest
    {
        [Required]
        public new string? ProductName { get; set; }
        public new bool Discontinued { get; set; }       
    }
}
