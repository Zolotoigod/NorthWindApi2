using NorthWindEFRepository.Entities;
using System.ComponentModel.DataAnnotations;

namespace NorthWindApi2.DTO
{
    public class CategoryRequest
    {
        [Required]
        [StringLength(15)]
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        public Category ToEntity()
        {
            return new Category()
            {
                Name = CategoryName,
                Description = Description,
            };
        }
    }
}
