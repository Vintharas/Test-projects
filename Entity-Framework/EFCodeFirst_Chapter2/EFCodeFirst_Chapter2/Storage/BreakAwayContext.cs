using System.Data.Entity;
using EFCodeFirst_Chapter2.Domain;

namespace EFCodeFirst_Chapter2.Storage
{
    public class BreakAwayContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
    }
}