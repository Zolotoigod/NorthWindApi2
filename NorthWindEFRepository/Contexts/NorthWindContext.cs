using Microsoft.EntityFrameworkCore;
using NorthWindEFRepository.Entities;

namespace NorthWindEFRepository.Contexts
{
    public class NorthWindContext : DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category>? Categories { get; set; }

        public virtual DbSet<Employee>? Employees { get; set; }

        public virtual DbSet<Product>? Products { get; set; }
    }
}
