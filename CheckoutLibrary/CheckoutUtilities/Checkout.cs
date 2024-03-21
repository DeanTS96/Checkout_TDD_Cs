using System.Text.RegularExpressions;
using Utilities;
namespace CheckoutLibrary;

public class Checkout
{
    private int _total = 0;
    private int _savings = 0;
    private readonly Dictionary<string, int> _prices;
    private readonly Dictionary<string, Dictionary<string, int>> _specialPrices;
    public readonly Dictionary<string, int> ItemList = new Dictionary<string, int>();

    public int Total 
    { 
        get { return _total; }
        set { _total = value; }
    }
    public int Savings 
    { 
        get { return _savings; }
        set { _savings = value; }
    }
    public Dictionary<string, int> Prices 
    { 
        get { return _prices; }
    }
    public Dictionary<string, Dictionary<string, int>> SpecialPrices 
    { 
        get { return _specialPrices; }
    }
    public Checkout(Dictionary<string, int> prices, Dictionary<string, Dictionary<string, int>> specialPrices)
    {
        this._prices = prices;
        this._specialPrices = specialPrices;
    }
    private static bool ContainsOnlyLetters(string item)
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
        return Prices[item];
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
    private int CalculateSavingsPerDeal(string item, int quantity, int specialPrice)
    {
            return GetPrice(item)*quantity - specialPrice;
    }
    private int CalculateTotalSavingsForItem(string item, int itemQuantity, int specialPriceQuantity, int specialPricePrice)
    {
        int numOfDeals = itemQuantity / specialPriceQuantity;
        return numOfDeals*CalculateSavingsPerDeal(item, specialPriceQuantity, specialPricePrice);
    }
    private void CalculateTotalSavings()
    {
        foreach(KeyValuePair<string, int> pair in ItemList)
        {
            string item = pair.Key;
            int itemQuantity = pair.Value;
            if(SpecialPrices.TryGetValue(item, out Dictionary<string, int> ?specialPrice))
            {
                Savings += CalculateTotalSavingsForItem(item, itemQuantity, specialPrice["quantity"], specialPrice["price"]);
            }
        }
    }
    public int GetTotalPrice()
    {
        CalculateTotalSavings();
        return Total-Savings;
    }
}
