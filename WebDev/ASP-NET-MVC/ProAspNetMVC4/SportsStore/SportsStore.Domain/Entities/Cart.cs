using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();
        public IEnumerable<CartLine> Lines { get { return lines; } } 

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lines.FirstOrDefault(l => l.Product.ProductID == product.ProductID);
            if (line == null)
            {
                lines.Add(new CartLine { Product = product, Quantity = quantity});
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lines.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lines.Sum(l => l.Product.Price*l.Quantity);
        }

        public void Clear()
        {
            lines.Clear();
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}