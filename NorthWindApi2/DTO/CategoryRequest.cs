using System.ComponentModel.DataAnnotations;

namespace NorthWindApi2.DTO
{
    public class CategoryRequest
    {
        [Required]
        [StringLength(15)]
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
