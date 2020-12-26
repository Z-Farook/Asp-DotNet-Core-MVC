using System.Collections;
using System.Collections.Generic;
namespace proj1forChap5.Models
{
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
}