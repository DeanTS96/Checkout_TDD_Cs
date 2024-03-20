using System.Text.RegularExpressions;
using Utilities;
namespace CheckoutLibrary;

public class Checkout
{
    private int _total = 0;
    private readonly Dictionary<string, int> _prices;
    private readonly Dictionary<string, Dictionary<string, int>> _specialPrices;
    public readonly Dictionary<string, int> ItemList = new Dictionary<string, int>();

    public int Total 
    { 
        get { return _total; }
        set { _total = value; }
    }
    public Checkout(Dictionary<string, int> prices, Dictionary<string, Dictionary<string, int>> specialPrices)
    {
        this._prices = prices;
        this._specialPrices = specialPrices;
    }
    private bool ContainsOnlyLetters(string item)
    {
        return Regex.IsMatch(item, RegexPatterns.LettersOnly);
    }
    public void Scan(string item)
    {
        if(!string.IsNullOrEmpty(item) && ContainsOnlyLetters(item))
        {
            AddItemQuantityToItemList(item);
            AddToTotal(item);
        }
    }
    private int GetPrice(string item)
    {
        return _prices[item];
    }
    private void AddToTotal(string item)
    {
        Total += GetPrice(item);
    }
    private int GetQuantity(string item)
    {
        return ItemList.TryGetValue(item, out int value) ? value: 0;
    }
    private void AddItemQuantityToItemList(string item)
    {
        int itemQuantity = GetQuantity(item);
        ItemList[item] = itemQuantity > 0 ? itemQuantity + 1: 1;
    }
    private int CalculateSavings(string item, int quantity, int specialPrice)
    {
            return GetPrice(item)*quantity - specialPrice;
    }
    public int GetTotalPrice()
    {
        foreach(KeyValuePair<string, int> pair in ItemList)
        {
            string item = pair.Key;
            if(_specialPrices.TryGetValue(item, out Dictionary<string, int> ?value))
            {
                int savings = CalculateSavings(item, value["quantity"], value["price"]);
                int numOfDeals = pair.Value / value["quantity"];
                Total -= savings*numOfDeals;
            }
        }
        return Total;
    }
}
