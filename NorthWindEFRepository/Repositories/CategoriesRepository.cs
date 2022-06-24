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
                    "Category",
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
                    "Category",
                    categoryId));

            category.Name = newCategory.Name;
            category.Description = newCategory.Description;

            await context.SaveChangesAsync();
        }

        public async Task Remove(int categoryId)
        {
            var category = await context.Categories!.FindAsync(categoryId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    "Category",
                    categoryId));
            context.Remove(category);

            await context.SaveChangesAsync();
        }

        public Task<int> GetCount()
        {
            return context.Categories!.CountAsync();
        }
    }
}
