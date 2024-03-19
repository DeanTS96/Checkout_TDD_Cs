using CheckoutLibrary;
namespace CheckoutLibraryTests;

[TestClass]
public class CheckoutMethodTests
{
    Dictionary<string, int> prices = new Dictionary<string, int>();
    Dictionary<string, int> specialPrices = new Dictionary<string, int>();
    //Happy Tests
    [TestMethod]
    public void ScanMethod_When_Passed_Single_Correct_Character_Adds_Item_To_ItemList()
    {
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("A");
        bool IsInItemList = checkout.ItemList.ContainsKey("A");

        Assert.IsTrue(IsInItemList, $"Scanned item is added to ItemList. EXPECTED: true; ACTUAL: {IsInItemList}");
    }
    [TestMethod]
    public void ScanMethod_When_Passed_Multiple_character_Length_Correct_String_Adds_Item_To_ItemList()
    {
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("ABC");
        bool IsInItemList = checkout.ItemList.ContainsKey("ABC");

        Assert.IsTrue(IsInItemList, $"Scanned item of multiple characters is added to ItemList. EXPECTED: true; ACTUAL: {IsInItemList}");
    }
    //Bad Tests
    [TestMethod]
    public void ScanMethod_When_Passed_Nothing_Do_Nothing()
    {
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("");
        bool IsInItemList = checkout.ItemList.ContainsKey("");

        Assert.IsFalse(IsInItemList, $"Scanned item of an empty string should not be added to ItemList. EXPECTED: false; ACTUAL: {IsInItemList}");
    }
    [TestMethod]
    public void ScanMethod_When_Passed_Not_A_Letter_Does_Nothing()
    {
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan(";");
        bool IsInItemList = checkout.ItemList.ContainsKey(";");

        Assert.IsFalse(IsInItemList, $"If scaned item contains non letters, it is not added to ItemList. EXPECTED: false; ACTUAL: {IsInItemList}");
    }
    [TestMethod]
    public void ScanMethod_When_Passed_Lower_Case_Letters_Does_Nothing()
    {
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("a");
        bool IsInItemList = checkout.ItemList.ContainsKey("a");

        Assert.IsFalse(IsInItemList, $"If scaned is a lower case letters, it is not added to ItemList. EXPECTED: false; ACTUAL: {IsInItemList}");
    }
    [TestMethod]
    public void ScanMethod_When_Passed_A_Longer_String_With_Lowercase_Letters_Included_Does_Nothing()
    {
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("AaB");
        bool IsInItemList = checkout.ItemList.ContainsKey("AaB");

        Assert.IsFalse(IsInItemList, $"If scaned item contains lower case letters, it is not added to ItemList. EXPECTED: false; ACTUAL: {IsInItemList}");
    }
}