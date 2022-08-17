using NorthWindEFRepository.BlogEntities;

namespace NorthWindApi2.DTO
{
    public class ArticleResponse : ArticleRequest
    {
        public ArticleResponse(BlogArticle entity)
        {
            Id = entity.Id;
            Text = entity.Text;
            Title = entity.Title;
            PublishDate = entity.PublishDate;
            EmployeeId = entity.EmployeeId;
        }

        public int Id { get; set; }
    }
}
  