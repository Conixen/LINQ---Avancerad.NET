namespace LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till Online dé Shope Dé SUT24");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("1. Hämta alla produkter i kategorin 'Electronics' och sortera dem efter pris (högst först)");
                Console.WriteLine("2. Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter");
                Console.WriteLine("3. Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden");
                Console.WriteLine("4. Hitta de 3 mest sålda produkterna baserat på OrderDetail-data");
                Console.WriteLine("5. Lista alla kategorier och antalet produkter i varje kategori");
                Console.WriteLine("6. Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr");
                Console.WriteLine("0. Avsluta");
                Console.WriteLine("-----------------------------------------------");

                Console.Write("Välj ett alternativ (0-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        testLINQ.GetProductsByCategory();
                        break;
                    case "2":
                        testLINQ.SupplierSaldo();
                        break;
                    case "3":
                        testLINQ.OrderValue();
                        break;
                    case "4":
                        testLINQ.MostSoldProduct();
                        break;
                    case "5":
                        testLINQ.CatagoriAndProducts();
                        break;
                    case "6":
                        testLINQ.OrderOver1K();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nTryck på en tangent för att fortsätta...");
                    Console.ReadKey();
                }
            }
        }
    }
}

