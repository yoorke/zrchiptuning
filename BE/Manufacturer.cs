using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace BE
{
	public class Manufacturer : BaseEntity
	{
		[SqlFieldNameAttribute("name")]
		public string Name { get; set; }

        [SqlFieldNameAttribute("imageUrl")]
        public string ImageUrl { get; set; }

        [SqlFieldNameAttribute("url")]
        public string Url { get; set; }


		public Manufacturer()
		{

		}

		public Manufacturer(string name, int id, string imageUrl, string url)
		{
		    this.Name = name;
			this.ID = id;
            this.ImageUrl = imageUrl;
            this.Url = url;
		}
	}
}