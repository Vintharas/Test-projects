using System.Data.Entity;
using SportStore.Domain.Entities;

namespace SportStore.Domain.Concrete
{
    /// <summary>
    /// Entity framework context that represents a unit of work design pattern. (EF code-first)
    /// </summary>
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}