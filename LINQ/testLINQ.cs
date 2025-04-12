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
    //Implementera följande queries med LINQ (välj antingen Method syntax eller Query syntax):

    //## Krav på implementationen

    //- Använd Entity Framework Core med Code First-approach
    //- Implementera modellerna och deras relationer (med navigation properties)
    //- Skapa migrations och seed-data för att fylla databasen med testdata
    //- Skapa en meny för att testa dina LINQ-queries

    //Din lösning ska demonstrera god förståelse för både Entity Framework och LINQ-operationer.
    public class testLINQ
    {

        //- []  Hämta alla produkter i kategorin "Electronics" och sortera dem efter pris (högst först)
        public static void GetProductsByCategory()
        {
            Console.WriteLine("Hämtar alla electronics");
            using (var context = new OnlineShopContext())
            {
                var allElectronics = context.Products
                    .Include(p => p.Category)
                    .Where(p => p.Category.Name == "Electronics")
                    .OrderByDescending(p => p.Price);

                foreach (var product in allElectronics) 
                {
                    Console.WriteLine($"{product.Name} - { product.Price } ");
                }
                Console.ReadKey();
            }
        }
        //- [ ] Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter
        public static void SupplierSaldo()
        {
            using (var context = new OnlineShopContext())
            {
                var lessThen10 = context.Suppliers
                    .Include(p => p.Products)
                    .Where(p => p.Products.Any(s => s.StockQuantity < 10))
                    .ToList();

                foreach(var supplier in lessThen10)
                {
                    Console.WriteLine($"Leverantör {supplier.Name} ");
                    foreach (var lessThen in supplier.Products.Where(s => s.StockQuantity < 10))
                    {
                        Console.WriteLine($"\tProdukt: {lessThen.Name}, Antal i lager: {lessThen.StockQuantity}");
                    }
                }
                Console.ReadKey();
            }
        }
        //- [ ] Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden
        public static void AvgOrderValue()
        {
            using (var context = new OnlineShopContext())
            {

            }
        }
        //- [ ] Hitta de 3 mest sålda produkterna baserat på OrderDetail-data
        public static void MostSoldProduct()
        {
            using (var context = new OnlineShopContext())
            {

            }
        }
        //- [ ] Lista alla kategorier och antalet produkter i varje kategori
        public static void CatagoriAndProducts()
        {
            using (var context = new OnlineShopContext())
            {
                var catAndPro = context.Categories
                    .Include(p => p.Products)
                    .Select(p => new
                    {
                        CategoryName = p.Name,
                        ProductAmount = p.Products.Count
                    })
                .ToList();

                foreach (var item in catAndPro)
                {
                    Console.WriteLine($"{item.CategoryName}: {item.ProductAmount} produkter");
                }
                Console.ReadKey();
            }
        }
        //- [ ] Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr
        public static void OrderOver1K()
        {
            using (var context = new OnlineShopContext())
            {

            }
        }
    }
}


