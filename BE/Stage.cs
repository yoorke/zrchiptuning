using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace BE
{
	public class Stage : BaseEntity
	{
		[SqlFieldNameAttribute("name")]
		public string Name { get; set; }


		public Stage()
		{

		}

		public Stage(string name, int id)
		{
		    this.Name = name;
			this.ID = id;
		}
	}
}