using System.Collections.Generic;

namespace proj1forChap6.Models
{
    public interface IDataSource
    {
        IEnumerable<Product> Products { get; }
    }
}