using CheckoutLibrary;
namespace CheckoutLibraryTests;

[TestClass]
public class CheckoutMethodTests
{
    [TestMethod]
    public void ScanMethod_When_Passed_Nothing_Do_Nothing()
    {
        Checkout checkout = new Checkout();
        checkout.Scan("");
        bool IsInItemList = checkout.ItemList.ContainsKey("");

        Assert.IsFalse(IsInItemList, $"Scanned item should not be added to ItemList. EXPECTED: false; ACTUAL: {IsInItemList}");
    }
        [TestMethod]
    public void ScanMethod_When_Passed_Single_Character_Adds_Item_To_ItemList()
    {
        Checkout checkout = new Checkout();
        checkout.Scan("A");
        bool IsInItemList = checkout.ItemList.ContainsKey("A");

        Assert.IsTrue(IsInItemList, $"Scanned item is added to ItemList. EXPECTED: true; ACTUAL: {IsInItemList}");
    }
}