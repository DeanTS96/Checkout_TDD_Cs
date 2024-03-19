using CheckoutLibrary;
namespace CheckoutLibraryTests;

[TestClass]
public class GetTotalPriceTests
{
    Dictionary<string, int> prices = new Dictionary<string, int>()
    {
        {"A", 30}
    };
    Dictionary<string, int> specialPrices = new Dictionary<string, int>();
    //Happy Tests
    [TestMethod]
    public void Method_Returns_0_When_No_Items_Have_Been_Scanned()
    {
        Checkout checkout = new Checkout(prices, specialPrices);
        int expected = 0;
        int actual = checkout.GetTotalPrice();

        Assert.AreEqual(expected, actual, $"Scanned item is added to ItemList. EXPECTED: {expected}; ACTUAL: {actual}");
    }
    public void Method_Returns_Correct_Ammount_When_Only_One_Item_Has_Been_Scanned()
    {
        Checkout checkout = new Checkout(prices, specialPrices);
        int expected = 0;
        int actual = checkout.GetTotalPrice();

        Assert.AreEqual(expected, actual, $"Scanned item is added to ItemList. EXPECTED: {expected}; ACTUAL: {actual}");
    }
    //Bad Tests
}