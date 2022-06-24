using NorthWindEFRepository.Entities;

namespace NorthWindApi2.DTO
{
    public class CategoryResponse : CategoryRequest
    {
        public CategoryResponse() { }

        public CategoryResponse(Category category)
        {
            CategoryId = category.Id;
            CategoryName = category.Name;
            Description = category.Description;
        }

        public int CategoryId { get; set; }
    }
}
