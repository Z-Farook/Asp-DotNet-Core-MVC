using System.Collections.Generic;
using System.Linq;
namespace proj1forChap5.Models
{
    public interface IItemSelection
    {
        IEnumerable<Item> Products { get; }
        IEnumerable<string> Names => Products.Select(p => p.Name);
    }
}
