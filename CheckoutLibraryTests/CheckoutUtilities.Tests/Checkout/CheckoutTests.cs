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

        Assert.IsFalse(IsInItemList, $"Scanned item should not be added to ItemList: expected false; Actual: {IsInItemList}");
    }
}