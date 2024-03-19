using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;
using Utilities;
namespace CheckoutLibrary;

public class Checkout
{
    public readonly Dictionary<string, int> ItemList = new Dictionary<string, int>();
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
}
