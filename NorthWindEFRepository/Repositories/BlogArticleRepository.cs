using Microsoft.EntityFrameworkCore;
using NorthWindEFRepository.BlogEntities;

namespace NorthWindEFRepository.Repositories
{
    public class BlogArticleRepository : IBlogArticleRepository
    {
        private readonly BloggingContext context;

        public BlogArticleRepository(BloggingContext setContext)
        {
            context = setContext;
        }

        public async Task<int> Add(BlogArticle obj)
        {
            await context.Articles!.AddAsync(obj);
            await context.SaveChangesAsync();
            return obj.Id;
        }

        public async Task<BlogArticle> GetById(int objectId)
        {
            return await context.Articles!.FindAsync(objectId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.BlogArticle,
                    objectId));
        }

        public async IAsyncEnumerable<BlogArticle> GetCollection(int offset, int limit)
        {
            var query = context.Articles!
                .Skip(offset)
                .Take(limit)
                .OrderByDescending(article => article.PublishDate)
                .AsAsyncEnumerable();
            await foreach (var blogArticle in query)
            {
                yield return blogArticle;
            }
        }

        public async Task<int> GetCount() => await context.Articles!.CountAsync();

        public async Task Remove(int objId)
        {
            var category = await context.Articles!.FindAsync(objId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.BlogArticle,
                    objId));
            context.Articles.Remove(category);

            await context.SaveChangesAsync();
        }

        public async Task Update(int objId, BlogArticle newObj)
        {
            var obj = await context.Articles!.FindAsync(objId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.BlogArticle,
                    objId));

            obj.Title = newObj.Title ?? obj.Title;
            obj.Text = newObj.Text ?? obj.Text;
            obj.PublishDate = newObj.PublishDate == default ? obj.PublishDate : newObj.PublishDate;
            obj.EmployeeId = newObj.EmployeeId == default ? obj.EmployeeId : newObj.EmployeeId;

            await context.SaveChangesAsync();
        }
    }
}
