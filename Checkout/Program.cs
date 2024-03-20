using CheckoutLibrary;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"A", 30}
        };
        Dictionary<string, Dictionary<string, int>> specialPrices = new Dictionary<string, Dictionary<string, int>>();
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("A");
        Console.WriteLine(checkout.ItemList["A"]);
    }
}
