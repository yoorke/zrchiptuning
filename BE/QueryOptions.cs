using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum SortOrder
    {
        Ascending,
        Descending
    }

    public class QueryOptions
    {
        public Dictionary<string, object> fieldValues { get; set; }
        public SortOrder SortOrder { get; set; }
    }
}
