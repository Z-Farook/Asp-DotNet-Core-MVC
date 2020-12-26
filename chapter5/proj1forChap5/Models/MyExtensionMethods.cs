namespace proj1forChap5.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this ShoppingCart cartParam)
        {
            decimal total = 0;
            foreach (Item x in cartParam.Items)
            {
                total += x?.Price ?? 0;
            }
            return total;
        }
    }
}