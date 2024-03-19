namespace CheckoutLibrary;

public class Checkout
{
    public Dictionary<string, int> ItemList = new Dictionary<string, int>();
    public void Scan(string item)
    {
        if(!string.IsNullOrEmpty(item))
        {
            ItemList[item] = ItemList.ContainsKey(item) ? ItemList[item] + 1: 1;
        }
    }
}
