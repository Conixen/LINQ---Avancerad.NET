namespace LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {

            //- []  Hämta alla produkter i kategorin "Electronics" och sortera dem efter pris (högst först)
            //testLINQ.GetProductsByCategory();

            ////- [ ] Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter
            //testLINQ.SupplierSaldo();

            ////- [ ] Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden
            //testLINQ.AvgOrderValue();

            ////- [ ] Hitta de 3 mest sålda produkterna baserat på OrderDetail-data
            //testLINQ.MostSoldProduct();

            ////- [ ] Lista alla kategorier och antalet produkter i varje kategori
            testLINQ.CatagoriAndProducts();

            ////- [ ] Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr
            //testLINQ.OrderOver1K();

        }
    }
}
