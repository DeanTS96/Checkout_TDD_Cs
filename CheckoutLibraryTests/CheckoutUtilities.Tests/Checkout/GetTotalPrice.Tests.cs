using CheckoutLibrary;
namespace CheckoutLibraryTests;

[TestClass]
public class GetTotalPriceTests
{
    //Happy Tests
    [TestMethod]
    public void Method_Returns_0_When_No_Items_Have_Been_Scanned()
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"A", 30}
        };
        Dictionary<string, Dictionary<string, int>> specialPrices = new Dictionary<string, Dictionary<string, int>>();
        Checkout checkout = new Checkout(prices, specialPrices);
        int expected = 0;
        int actual = checkout.GetTotalPrice();

        Assert.AreEqual(expected, actual, $"Scanned item is added to ItemList. EXPECTED: {expected}; ACTUAL: {actual}");
    }
    [TestMethod]
    public void Method_Returns_Correct_Ammount_When_Only_One_Item_Has_Been_Scanned()
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"A", 30}
        };
        Dictionary<string, Dictionary<string, int>> specialPrices = new Dictionary<string, Dictionary<string, int>>();
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("A");
        int expected = 30;
        int actual = checkout.GetTotalPrice();

        Assert.AreEqual(expected, actual, $"Scanned item is added to ItemList. EXPECTED: {expected}; ACTUAL: {actual}");
    }
    [TestMethod]
    public void Method_Returns_Correct_Ammount_When_Multiple_Items_Have_Been_Scanned()
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"A", 30},
            {"B", 20}
        };
        Dictionary<string, Dictionary<string, int>> specialPrices = new Dictionary<string, Dictionary<string, int>>();
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("A");
        int expected = 80;
        int actual = checkout.GetTotalPrice();

        Assert.AreEqual(expected, actual, $"Scanned item is added to ItemList. EXPECTED: {expected}; ACTUAL: {actual}");
    }
    [TestMethod]
    public void Method_Returns_Correct_Special_Price_When_A_Single_Item_Has_Been_Scanned_And_That_Item_Has_A_Special_Price()
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"A", 30}
        };
        Dictionary<string, Dictionary<string, int>> specialPrices = new Dictionary<string, Dictionary<string, int>>()
        {
            {"A", new Dictionary<string, int>
                {
                   {"quantity", 1}, 
                   {"price", 20},
                }
            }
        };
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("A");
        int expected = 20;
        int actual = checkout.GetTotalPrice();

        Assert.AreEqual(expected, actual, $"Scanned item is added to ItemList. EXPECTED: {expected}; ACTUAL: {actual}");
    }
    //Bad Tests
}