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
    public void Method_Returns_Correct_Ammount_When_One_Item_Has_Been_Scanned_Multiple_Times()
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"A", 30}
        };
        Dictionary<string, Dictionary<string, int>> specialPrices = new Dictionary<string, Dictionary<string, int>>();
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("A");
        checkout.Scan("A");
        int expected = 60;
        int actual = checkout.GetTotalPrice();

        Assert.AreEqual(expected, actual, $"Scanned item is added to ItemList. EXPECTED: {expected}; ACTUAL: {actual}");
    }
    [TestMethod]
    public void Method_Returns_Correct_Ammount_When_Multiple_Different_Items_Have_Been_Scanned()
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
    public void Method_Returns_Correct_Price_When_A_Single_Item_Has_Been_Scanned_And_That_Item_Has_A_Special_Price()
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
    [TestMethod]
    public void Method_Returns_Correct_Price_When_Multiple_Items_Have_Been_Scanned_With_Special_Prices()
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"A", 30},
            {"B", 50}
        };
        Dictionary<string, Dictionary<string, int>> specialPrices = new Dictionary<string, Dictionary<string, int>>()
        {
            {"A", new Dictionary<string, int>
                {
                   {"quantity", 1}, 
                   {"price", 20},
                }
            },
            {"B", new Dictionary<string, int>
                {
                   {"quantity", 1}, 
                   {"price", 40},
                }
            }
        };
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("A");
        checkout.Scan("B");
        int expected = 60;
        int actual = checkout.GetTotalPrice();

        Assert.AreEqual(expected, actual, $"Scanned item is added to ItemList. EXPECTED: {expected}; ACTUAL: {actual}");
    }
    [TestMethod]
    public void Method_Returns_Correct_Price_For_A_Special_price_Item_That_Requires_Multiples_Of_That_Item_To_Get_The_Special_Price()
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"C", 90},
        };
        Dictionary<string, Dictionary<string, int>> specialPrices = new Dictionary<string, Dictionary<string, int>>()
        {
            {"C", new Dictionary<string, int>
                {
                   {"quantity", 2}, 
                   {"price", 150},
                }
            },
        };
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("C");
        checkout.Scan("C");
        int expected = 150;
        int actual = checkout.GetTotalPrice();

        Assert.AreEqual(expected, actual, $"Scanned item is added to ItemList. EXPECTED: {expected}; ACTUAL: {actual}");
    }
    [TestMethod]
    public void Method_Returns_Correct_Price_For_A_Special_price_Item_That_Requires_Multiples_Of_That_Item_To_Get_The_Special_Price_And_There_Is_Still_An_Item_That_Matches_The_Deal_Item_Left_Over()
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"C", 90},
        };
        Dictionary<string, Dictionary<string, int>> specialPrices = new Dictionary<string, Dictionary<string, int>>()
        {
            {"C", new Dictionary<string, int>
                {
                   {"quantity", 2}, 
                   {"price", 150},
                }
            },
        };
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("C");
        checkout.Scan("C");
        checkout.Scan("C");
        int expected = 240;
        int actual = checkout.GetTotalPrice();

        Assert.AreEqual(expected, actual, $"Scanned item is added to ItemList. EXPECTED: {expected}; ACTUAL: {actual}");
    }
    [TestMethod]
    public void Method_Returns_Correct_Price_For_A_Special_price_Item_That_Requires_Multiples_Of_That_Item_To_Get_The_Special_Price_And_There_Are_Multiple_Deal_Quantities_Scanned()
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"C", 90},
        };
        Dictionary<string, Dictionary<string, int>> specialPrices = new Dictionary<string, Dictionary<string, int>>()
        {
            {"C", new Dictionary<string, int>
                {
                   {"quantity", 2}, 
                   {"price", 150},
                }
            },
        };
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("C");
        checkout.Scan("C");
        checkout.Scan("C");
        checkout.Scan("C");
        int expected = 300;
        int actual = checkout.GetTotalPrice();

        Assert.AreEqual(expected, actual, $"Scanned item is added to ItemList. EXPECTED: {expected}; ACTUAL: {actual}");
    }
    [TestMethod]
    public void Method_Returns_Total_Price_When_Passed_A_More_Complex_Operation()
    {
        Dictionary<string, int> prices = new Dictionary<string, int>()
        {
            {"A", 30},
            {"B", 50},
            {"C", 90},
            {"E", 10},
            {"F", 200},
            {"G", 120},
        };
        Dictionary<string, Dictionary<string, int>> specialPrices = new Dictionary<string, Dictionary<string, int>>()
        {
            {"A", new Dictionary<string, int>
                {
                   {"quantity", 1}, 
                   {"price", 20},
                }
            },
            {"B", new Dictionary<string, int>
                {
                   {"quantity", 1}, 
                   {"price", 40},
                }
            },
            {"C", new Dictionary<string, int>
                {
                   {"quantity", 2}, 
                   {"price", 150},
                }
            },
            {"F", new Dictionary<string, int>
                {
                   {"quantity", 3}, 
                   {"price", 400},
                }
            },
            {"G", new Dictionary<string, int>
                {
                   {"quantity", 2}, 
                   {"price", 200},
                }
            }
        };
        Checkout checkout = new Checkout(prices, specialPrices);
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("G");
        checkout.Scan("F");
        checkout.Scan("F");
        checkout.Scan("E");
        checkout.Scan("C");
        checkout.Scan("C");
        checkout.Scan("F");
        checkout.Scan("E");
        int expected = 730;
        int actual = checkout.GetTotalPrice();

        Assert.AreEqual(expected, actual, $"Scanned item is added to ItemList. EXPECTED: {expected}; ACTUAL: {actual}");
    }
    //Bad Tests
}