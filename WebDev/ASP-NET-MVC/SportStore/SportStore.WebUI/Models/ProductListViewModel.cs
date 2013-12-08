using System.Collections.Generic;
using SportStore.Domain.Entities;

namespace SportStore.WebUI.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}