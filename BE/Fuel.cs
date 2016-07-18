using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace BE
{
	public class Fuel : BaseEntity
	{
		[SqlFieldNameAttribute("name")]
		public string Name { get; set; }


		public Fuel()
		{

		}

		public Fuel(string name, int id)
		{
		    this.Name = name;
			this.ID = id;
		}
	}
}