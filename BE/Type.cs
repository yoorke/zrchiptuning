using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace BE
{
	public class Type : BaseEntity
	{
		[SqlFieldNameAttribute("name")]
		public string Name { get; set; }

        [SqlFieldNameAttribute("url")]
        public string Url { get; set; }


		public Type()
		{

		}

		public Type(string name, int id, string url)
		{
		    this.Name = name;
			this.ID = id;
            this.Url = url;
		}
	}
}