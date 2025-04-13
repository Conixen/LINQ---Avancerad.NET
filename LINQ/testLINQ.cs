using LINQ.Data;
using LINQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class testLINQ
    {                               // Method Syntax on all methods

        // Hämta alla produkter i kategorin "Electronics" och sortera dem efter pris (högst först)
        public static void GetProductsByCategory()
        {
            Console.Clear();
            Console.WriteLine("Hämtar alla prdukter i Electronics kategorin:\n ");
            using (var context = new OnlineShopContext())
            {
                var allElectronics = context.Products
                    .Include(p => p.Category)       // Load in related data from category
                    .Where(p => p.Category.Name == "Electronics")   // Filter to only include Electronics
                    .OrderByDescending(p => p.Price);   // sorting from higest to lowesst

                foreach (var product in allElectronics) 
                {
                    Console.WriteLine($"{product.Name} | { product.Price } ");
                }
            }
            // query syntax
            // var produkter = from p in context.Products
            //                where p.Category.Name == "Electronics"
            //                orderby p.Price descending
            //                select p;
        }
        // Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter
        public static void SupplierSaldo()
        {
            Console.Clear();
            Console.WriteLine("Alla leverantörer med produkter med lagersaldo under 10:\n ");
            using (var context = new OnlineShopContext())
            {
                var lessThen10 = context.Suppliers
                    .Include(p => p.Products)
                    .Where(p => p.Products.Any(s => s.StockQuantity < 10))      // any: Checks if at least one product has stock under 10
                    .ToList();

                Console.WriteLine("-----------------------------------------------");
                foreach (var supplier in lessThen10)
                {
                    Console.WriteLine($"\nLeverantör {supplier.Name}");

                    foreach (var lessThen in supplier.Products.Where(s => s.StockQuantity < 10))    //  Using Where for fileter results
                    {
                        Console.WriteLine($"Produkt: {lessThen.Name} | {lessThen.StockQuantity} St i Lager");
                    }
                    Console.WriteLine("\n-----------------------------------------------");
                }
            }
        }
        // Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden
        public static void OrderValue()
        {
            Console.Clear();
            Console.WriteLine("Totala värdet under mars månad:");
            using (var context = new OnlineShopContext())
            {
                // var latestOrderValue = new context.Orders
                
                // DateTime aboutAMonthAgo = DateTime.Now.AddMonths(-1);        // range with in 1 month

                var fromDate = new DateTime(2025, 3, 1);        // getting the range to serach within March
                var toDate = new DateTime(2025, 3, 31);

                var totalOrderValue = context.Orders
                    .Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate)
                    .Sum(o => o.TotalAmount);           // Adding up all the total amount during march

                Console.WriteLine($"\nTotalt ordervärde senaste månaden: {totalOrderValue} kr");
            }
        }
        // Hitta de 3 mest sålda produkterna baserat på OrderDetail-data
        public static void MostSoldProduct()
        {
            Console.Clear();
            using (var context = new OnlineShopContext())
            {
                var topProducts = context.OrderDetails
                    .GroupBy(d => d.Product)
                    .Select(g => new        // create a new anonymus object with product and quantity sold
                    {
                        Product = g.Key,
                        TotalQuantity = g.Sum(d => d.Quantity)
                    })
                    .OrderByDescending(p => p.TotalQuantity)
                    .Take(3)        // Get the top 3 
                    .ToList();

                int numb = 1;
                if (topProducts.Any())      // checks if list is not null
                {
                    Console.WriteLine("\nTopp 3 mest sålda produkter:\n ");
                    foreach (var item in topProducts)
                    {
                        Console.WriteLine($"{numb}: {item.Product.Name} | Sålda: {item.TotalQuantity} st");
                        numb++;
                    }
                }
                else
                {
                    Console.WriteLine("\nInga produkter har sålts ännu.");
                }
            }
        }
        // Lista alla kategorier och antalet produkter i varje kategori
        public static void CatagoriAndProducts()
        {
            Console.Clear();
            Console.WriteLine("Antal produkter i varje kategori:");
            using (var context = new OnlineShopContext())
            {
                var catAndPro = context.Categories
                    .Include(p => p.Products)
                    .Select(p => new        // creating new anonymus object with product name and count
                    {
                        CategoryName = p.Name,
                        ProductAmount = p.Products.Count    // counts number of products in each category
                    })
                .ToList();

                foreach (var item in catAndPro)
                {
                    Console.WriteLine($"\nKategory: {item.CategoryName} | Antal: {item.ProductAmount} produkter");
                }
            }
        }
        // Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr
        public static void OrderOver1K()
        {
            Console.Clear();
            using (var context = new OnlineShopContext())
            {
                var over1k = context.Orders
                    //.Include(cdp => cdp.Product)
                    .Include(cdp => cdp.OrderDetails).ThenInclude(cdp => cdp.Product)       // include related data from customer and orderdetalies
                    .Include(cdp => cdp.Customer)                                           // thenInclude load product data for each orderdetail
                    .ToList();

                Console.WriteLine("\nHär är alla ordrar som överstiger 1000 kr");
                Console.WriteLine("\n-----------------------------------------------");


                foreach (var orderInfo in over1k)
                {
                    Console.WriteLine($"\nKund: {orderInfo.Customer.Name} | Mail: {orderInfo.Customer.Email} | Telefon: {orderInfo.Customer.Phone}");
                    Console.WriteLine($"OrderID: {orderInfo.Id} | Belop: {orderInfo.TotalAmount}kr\nBestäld: {orderInfo.OrderDate} | Status: {orderInfo.Status}");
                    Console.WriteLine("Produkter i ordern:");
                    foreach (var product in orderInfo.OrderDetails)
                    {                                               // Multiply quantity with price if they orderderd more than 1 of the product
                        Console.WriteLine($"Produkt: {product.Product.Name} | Antal: {product.Quantity} | Styck/Total Pris: {product.UnitPrice} / {product.UnitPrice * product.Quantity} kr");
                    }
                    Console.WriteLine("\n-----------------------------------------------");
                }

            }
        }
    }
}


