namespace CheckoutLibrary;

public class Checkout
{
    public Dictionary<string, int> ItemList = new Dictionary<string, int>();
    public void Scan(string item)
    {
        if(!string.IsNullOrEmpty(item))
        {
            ItemList[item] = ItemList.TryGetValue(item, out int value) ? value + 1: 1;
        }
    }
}
