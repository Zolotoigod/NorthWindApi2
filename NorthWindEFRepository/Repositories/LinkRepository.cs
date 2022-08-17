using Microsoft.EntityFrameworkCore;
using NorthWindEFRepository.BlogEntities;
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
            await context.Links!.AddAsync(link);
            await context.SaveChangesAsync();
            return link.ID;
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<Link> GetRelatedProduct(int articleId)
        {
            var query = context.Links!.Where(l => l.ArticleId == articleId).AsAsyncEnumerable();
            await foreach (var link in query)
            {
                yield return link;
            }
        }

        /// <inheritdoc/>
        public async Task RemoveLink(int articleId, int productId)
        {
            var link = await context.Links!
                .Where(l => l.ArticleId == articleId && l.ProductId == productId)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Link,
                    $"product id {productId}, article id {articleId}")); ;

            context.Links!.Remove(link);
            await context.SaveChangesAsync();
        }
    }
}
