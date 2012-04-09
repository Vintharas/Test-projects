using System.Linq;
using SportStore.Domain.Entities;
using SportStore.Domain.Interfaces;

namespace SportStore.Domain.Concrete
{
    /// <summary>
    /// EF product repository
    /// </summary>
    public class EFProductRepository : IProductRepository
    {
        private readonly EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
    }
}