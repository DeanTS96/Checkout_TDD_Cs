using CheckoutLibrary;

class Program
{
    static void Main(string[] args)
    {
        Checkout checkout = new Checkout();
        checkout.Scan("B");
        Console.WriteLine(checkout.ItemList["B"]);
    }
}
