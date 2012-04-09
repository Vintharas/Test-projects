using System.Data.Entity;
using TestingEFCodeFirst.Model;

namespace TestingEFCodeFirst.Storage
{
    public class WebsiteContext : DbContext
    {

        public DbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        
    }
}