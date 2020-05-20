namespace RevatrueP1.Business_Logic
{
    public class checkStock
    {
        // checks whether store has enough stock
        public bool checkStoreInventory(int inventory, int quantity)
        {
            return inventory >= quantity;
        }
    }
}
