using System.Text.RegularExpressions;

namespace CheckoutLibrary;

public class Checkout
{
    public Dictionary<string, int> ItemList = new Dictionary<string, int>();
    public void Scan(string item)
    {
        string pattern = "^[A-Z]+$";
        bool containsOnlyLetters = Regex.IsMatch(item, pattern);
        if(!string.IsNullOrEmpty(item) && containsOnlyLetters)
        {
            ItemList[item] = ItemList.TryGetValue(item, out int value) ? value + 1: 1;
        }
    }
}
