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
    private bool ContainsOnlyLetters(string item)
    {
        return Regex.IsMatch(item, RegexPatterns.LettersOnly);
    }
    public void Scan(string item)
    {
        if(!string.IsNullOrEmpty(item) && ContainsOnlyLetters(item))
        {
            AddItemToItemList(item);
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
        return ItemList.TryGetValue(item, out int value) ? value + 1: 1;
    }
    private void AddItemToItemList(string item)
    {
        ItemList[item] = GetQuantity(item);
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
