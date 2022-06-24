namespace NorthWindApi2.DTO
{
    public class CategoryResponse : CategoryRequest
    {
        public int CategoryId { get; set; }

        public string? PicturePath { get; set; }
    }
}
