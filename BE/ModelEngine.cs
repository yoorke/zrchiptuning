using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace BE
{
	public class ModelEngine : BaseEntity
	{
		[SqlFieldNameAttribute("modelid", "Model", "id", Relation.OneToOne)]
		public Model Model { get; set; }

		[SqlFieldNameAttribute("engineid", "Engine", "id", Relation.OneToOne)]
		public Engine Engine { get; set; }


		public ModelEngine()
		{

		}

		public ModelEngine(Model model, Engine engine, int id)
		{
		    this.Model = model;
		    this.Engine = engine;
			this.ID = id;
		}
	}
}