using Microsoft.EntityFrameworkCore;
using NorthWindEFRepository.BlogEntities;
using NorthWindEFRepository.Contexts;
using NorthWindEFRepository.Entities;
using System;
using System.Collections.Generic;

namespace NorthWindEFRepository.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly BloggingContext context;

        public LinkRepository(BloggingContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<int> CreateLink(int articleId, int productId)
        {
            var link = new Link { ArticleId = articleId, ProductId = productId };
            await context.Link!.AddAsync(link);
            return link.ID;
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<Link> GetRelatedProduct(int articleId)
        {
            var query = context.Link!.Where(l => l.ArticleId == articleId).AsAsyncEnumerable();
            await foreach (var productId in query)
            {
                yield return productId;
            }
        }

        /// <inheritdoc/>
        public async Task RemoveLink(int articleId, int productId)
        {
            var link = await context.Link!
                .Where(l => l.ArticleId == articleId && l.ProductId == productId)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Link,
                    $"product id {productId}, article id {articleId}")); ;

            context.Link!.Remove(link);
        }
    }
}
