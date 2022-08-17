using NorthWindApi2.DTO;
using NorthWindEFRepository.Repositories;

namespace NorthWindApi2.Services
{
    public class BlogArticleService : IBlogArticleService
    {
        private readonly IBlogArticleRepository repository;

        public BlogArticleService(IBlogArticleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Create(ArticleRequest article)
        {
            return await repository.Add(article.ToEntity());
        }

        public async Task Delete(int articleId)
        {
            await repository.Remove(articleId);
        }

        public async IAsyncEnumerable<ArticleResponse> FindAll(int offset, int limit)
        {
            await foreach (var article in repository.GetCollection(offset, limit))
            {
                yield return new ArticleResponse(article);
            }
        }

        public async Task<ArticleResponse> FindById(int articleId)
        {
            return new ArticleResponse(await repository.GetById(articleId));
        }

        public async Task Update(int articleId, ArticleRequest article)
        {
            var old = await repository.GetById(articleId);

            old.Text = article.Text ?? old.Text;
            old.Title = article.Title ?? old.Title;
            old.EmployeeId = article.EmployeeId == 0 ? old.EmployeeId : article.EmployeeId;
            old.PublishDate = article.PublishDate == default ? old.PublishDate : article.PublishDate;
        }
    }
}
