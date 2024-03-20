using System.Text.RegularExpressions;
using Utilities;
namespace CheckoutLibrary;

public class Checkout
{
    private int _total = 0;
    private readonly Dictionary<string, int> _prices;
    private readonly Dictionary<string, int> _specialPrices;
    public readonly Dictionary<string, int> ItemList = new Dictionary<string, int>();

    public int Total 
    { 
        get { return _total; }
        set { _total = value; }
    }
    public Checkout(Dictionary<string, int> prices, Dictionary<string, int> specialPrices)
    {
        this._prices = prices;
        this._specialPrices = specialPrices;
    }
    public void Scan(string item)
    {
        bool containsOnlyLetters = Regex.IsMatch(item, RegexPatterns.LettersOnly);
        if(!string.IsNullOrEmpty(item) && containsOnlyLetters)
        {
            AddItemToItemList(item);
            Total += _prices[item];
        }
    }
    private void AddItemToItemList(string item)
    {
        int quantity = ItemList.TryGetValue(item, out int value) ? value + 1: 1;
        ItemList[item] = quantity;
    }
    public int GetTotalPrice()
    {
        /*foreach(KeyValuePair<string, int> pair in ItemList)
        {
            (string item, int quantity) = pair;
            Total += _prices[item];
        }*/
        return Total;
    }
}
