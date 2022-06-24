using Microsoft.EntityFrameworkCore;
using NorthWindEFRepository.BlogEntities;

namespace NorthWindEFRepository.Contexts
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        {
        }

        public DbSet<BlogArticle>? BlogArticles { get; set; }

        public DbSet<Link>? Link { get; set; }

        public DbSet<Comment>? Comments { get; set; }
    }
}
