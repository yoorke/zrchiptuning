using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace BE
{
	public class CustomPageCategory : BaseEntity
	{
		[SqlFieldNameAttribute("name")]
		public string Name { get; set; }


		public CustomPageCategory()
		{

		}

		public CustomPageCategory(string name, int id)
		{
		    this.Name = name;
		    this.ID = id;
		}
	}
}