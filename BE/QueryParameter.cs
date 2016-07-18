using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class QueryParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public QueryParameter(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
