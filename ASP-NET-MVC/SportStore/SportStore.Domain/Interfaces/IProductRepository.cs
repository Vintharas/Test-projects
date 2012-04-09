using System.Linq;
using SportStore.Domain.Entities;

namespace SportStore.Domain.Interfaces
{
    /// <summary>
    /// Interface that defines a contract for a product repository
    /// </summary>
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }  
    }
}