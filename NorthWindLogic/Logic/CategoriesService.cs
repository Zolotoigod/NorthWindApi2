using NorthWindApi2.DTO;
using NorthWindEFRepository.Repositories;

namespace NorthWindApi2.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository categories;

        public CategoriesService(ICategoriesRepository categories)
        {
            this.categories = categories;
        }


        /// <iheritdoc/>
        public async IAsyncEnumerable<CategoryResponse> GetCollection(int offset, int limit)
        {
            await foreach (var category in categories.GetCollection(offset, limit))
            {
                yield return new CategoryResponse(category);
            }
        }

        /// <iheritdoc/>
        public async Task<CategoryResponse> Get(int categoryId)
        {
            return new CategoryResponse(await categories.GetById(categoryId));
        }

        /// <iheritdoc/>
        public async Task<int> Create(CategoryRequest productCategory)
        {
            return await categories.Add(productCategory.ToEntity());
        }

        /// <iheritdoc/>
        public async Task Destroy(int categoryId)
        {
            await categories.Remove(categoryId);
        }

        /// <iheritdoc/>
        public async Task Update(int categoryId, CategoryRequest productCategory)
        {
            await categories.Update(categoryId, productCategory.ToEntity());
        }

        /// <iheritdoc/>
        public async Task<int> GetCount()
        {
            return await categories.GetCount();
        }

        /// <iheritdoc/>
        public async IList<CategoryResponse> LookupByName(IList<string> names)
        {
            await foreach (var category in categories.LookupByName(names))
            {
                yield return new CategoryResponse(category);
            }
        }
    }
}
