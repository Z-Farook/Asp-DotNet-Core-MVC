using System.Collections;
using System.Collections.Generic;
namespace proj1forChap5.Models
{

#if false
    //Applying Extension Methods to an Interface
    public class ShoppingCart : IEnumerable<Item>
    {
        public IEnumerable<Item> Items { get; set; }

        public IEnumerator<Item> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
#endif

    #region Default Implementations in Interfaces
    // we add IEnumerable<Item> also so that other methods wil
    public class ShoppingCart : IItemSelection, IEnumerable<Item>
    {
        private List<Item> itemList = new List<Item>();
        public IEnumerable<Item> Products { get => itemList; }

        //Constructor 
        public ShoppingCart(params Item[] items)
        {
            itemList.AddRange(items);
        }


        public IEnumerable<Item> Items { get; set; }
        public IEnumerator<Item> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    #endregion
}