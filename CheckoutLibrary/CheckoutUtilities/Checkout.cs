using System.Text.RegularExpressions;
using Utilities;
namespace CheckoutLibrary;

public class Checkout
{
    private int _total = 0;
    private readonly Dictionary<string, int> _prices;
    private readonly Dictionary<string, int> _specialPrices;
    public readonly Dictionary<string, int> ItemList = new Dictionary<string, int>();

    private int Total { get; set;}
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
        }
    }
    private void AddItemToItemList(string item)
    {
        ItemList[item] = ItemList.TryGetValue(item, out int value) ? value + 1: 1;
    }
    public int GetTotalPrice()
    {
        return this._total;
    }
}
