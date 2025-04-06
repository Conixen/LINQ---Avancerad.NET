using LINQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class testLINQ
    {
        private readonly OnlineShopContext _context;
        public testLINQ(OnlineShopContext context)
        {
            _context = context;
        }

        public void GetProductsByCategory(string categoryName)
        {
            var products = _context.Products
                .Where(p => p.Category.Name == categoryName)
                .ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - {product.Price} SEK");
            }
        }
    }
}

