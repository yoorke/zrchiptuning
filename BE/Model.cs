using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace BE
{
	public class Model : BaseEntity
	{
		[SqlFieldNameAttribute("name")]
		public string Name { get; set; }

		[SqlFieldNameAttribute("typeid", "Type", "id", Relation.OneToOne)]
		public Type Type { get; set; }

		[SqlFieldNameAttribute("manufacturerid", "Manufacturer", "id", Relation.OneToOne)]
		public Manufacturer Manufacturer { get; set; }

        [SqlFieldNameAttribute("modelid", "Engine", "id", Relation.OneToMany, "getByModelID")]
        public List<Engine> Engines { get; set; }

        [SqlFieldNameAttribute("imageUrl")]
        public string ImageUrl { get; set; }

        [SqlFieldNameAttribute("url")]
        public string Url { get; set; }

        [SqlFieldNameAttribute("supplierID")]
        public int SupplierID { get; set; }


		public Model()
		{

		}

		public Model(string name, Type type, Manufacturer manufacturer, int id, List<Engine> engines, string imageUrl, string url)
		{
		    this.Name = name;
		    this.Type = type;
		    this.Manufacturer = manufacturer;
			this.ID = ID;
            this.Engines = engines;
            this.ImageUrl = imageUrl;
            this.Url = url;
		}
	}
}