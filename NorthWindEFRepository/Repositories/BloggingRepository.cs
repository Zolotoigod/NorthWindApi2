using Microsoft.EntityFrameworkCore;
using NorthWindEFRepository.BlogEntities;
using NorthWindEFRepository.Contexts;

namespace NorthWindEFRepository.Repositories
{
    public class BloggingRepository : IBloggingRepository
    {
        private readonly BloggingContext context;

        public BloggingRepository(BloggingContext setContext)
        {
            context = setContext;
        }

        public async Task<int> Add(BlogArticle obj)
        {
            await context.BlogArticles!.AddAsync(obj);
            await context.SaveChangesAsync();
            return obj.Id;
        }

        public async Task<BlogArticle> GetById(int objectId)
        {
            return await context.BlogArticles!.FindAsync(objectId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.BlogArticle,
                    objectId));
        }

        public async IAsyncEnumerable<BlogArticle> GetCollection(int offset, int limit)
        {
            var query = context.BlogArticles!.Skip(offset).Take(limit).AsAsyncEnumerable();
            await foreach (var blogArticle in query)
            {
                yield return blogArticle;
            }
        }

        public async Task<int> GetCount() => await context.BlogArticles!.CountAsync();

        public async Task Remove(int objId)
        {
            var category = await context.BlogArticles!.FindAsync(objId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.BlogArticle,
                    objId));
            context.BlogArticles.Remove(category);

            await context.SaveChangesAsync();
        }

        public async Task Update(int objId, BlogArticle newObj)
        {
            var obj = await context.BlogArticles!.FindAsync(objId)
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
