using Microsoft.EntityFrameworkCore;
using NorthWindEFRepository.BlogEntities;

namespace NorthWindEFRepository
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        {
        }

        public DbSet<BlogArticle>? Articles { get; set; }

        public DbSet<Link>? Links { get; set; }

        public DbSet<Comment>? Comments { get; set; }
    }
}
