using CheckoutLibrary;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> prices = new Dictionary<string, int>();
        Dictionary<string, int> specialPrices = new Dictionary<string, int>();
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("B");
        Console.WriteLine(checkout.ItemList["B"]);
    }
}
