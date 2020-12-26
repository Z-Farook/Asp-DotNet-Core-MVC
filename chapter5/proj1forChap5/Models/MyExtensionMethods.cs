using System.Collections.Generic;
namespace proj1forChap5.Models
{
    public static class MyExtensionMethods
    {

#if false
        public static decimal TotalPrices(this ShoppingCart cartParam)
        {
            decimal total = 0;
            foreach (Item x in cartParam.Items)
            {
                total += x?.Price ?? 0;
            }
            return total;
        }
#endif

        // Applying Extension Methods to an Interface
        public static decimal TotalPrices(this IEnumerable<Item> items)
        {
            decimal total = 0;
            foreach (Item x in items)
            {
                total += x?.Price ?? 0;
            }
            return total;
        }
        public static IEnumerable<Item> FilterByPrice(this IEnumerable<Item> productEnum, decimal minimumPrice)
        {
            foreach (Item prod in productEnum)
            {
                if ((prod?.Price ?? 0) >= minimumPrice)
                {
                    yield return prod;
                }
            }
        }
    }
}