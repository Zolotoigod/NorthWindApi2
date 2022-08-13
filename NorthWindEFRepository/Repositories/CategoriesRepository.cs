using Microsoft.EntityFrameworkCore;
using NorthWindEFRepository.Contexts;
using NorthWindEFRepository.Entities;

namespace NorthWindEFRepository.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly NorthWindContext context;

        public CategoriesRepository(NorthWindContext setContext)
        {
            context = setContext;
        }

        public async Task<Category> GetById(int categoryId)
        {
            return await context.Categories!.FindAsync(categoryId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Category,
                    categoryId));
        }

        public async IAsyncEnumerable<Category> GetCollection(int offset, int limit)
        {
            var query = context.Categories!.Skip(offset).Take(limit).AsAsyncEnumerable();
            await foreach (var category in query)
            {
                yield return category;
            }
        }

        public async Task<int> Add(Category category)
        {
            await context.Categories!.AddAsync(category);
            context.SaveChanges();
            return category.Id;
        }

        public async Task Update(int categoryId, Category newCategory)
        {
            var category = await context.Categories!.FindAsync(categoryId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Category,
                    categoryId));

            category.Name = newCategory.Name ?? category.Name;
            category.Description = newCategory.Description ?? category.Description;

            await context.SaveChangesAsync();
        }

        public async Task Remove(int categoryId)
        {
            var category = await context.Categories!.FindAsync(categoryId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Category,
                    categoryId));
            context.Categories.Remove(category);

            await context.SaveChangesAsync();
        }

        public async Task<int> GetCount() => await context.Categories!.CountAsync();

        // prerelise
        public async IAsyncEnumerable<Category> LookupByName(IList<string> names)
        {
            var query = context.Categories!.Where(c => names.Contains(c.Name)).AsAsyncEnumerable();
            await foreach (var category in query)
            {
                yield return category;
            }
        }

        public async Task UpdatePicture(int categoryId, byte[]? newPicture)
        {
            var category = await GetById(categoryId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Picture,
                    categoryId));

            category.Picture = newPicture;

            await context.SaveChangesAsync();
        }

        public async Task<Stream> ShowPicture(int id)
        {
            var category = await GetById(id)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Picture,
                    id));

            return new MemoryStream(category.Picture!);
        }
    }
}
