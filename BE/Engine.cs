using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace BE
{
	public class Engine : BaseEntity
	{
		[SqlFieldNameAttribute("name")]
		public string Name { get; set; }

		[SqlFieldNameAttribute("capacity")]
		public double Capacity { get; set; }

		[SqlFieldNameAttribute("torq")]
		public int Torq { get; set; }

		[SqlFieldNameAttribute("powerkw")]
		public int PowerKw { get; set; }

		[SqlFieldNameAttribute("powerks")]
		public int PowerKs { get; set; }

		[SqlFieldNameAttribute("maxspeed")]
		public int MaxSpeed { get; set; }

		[SqlFieldNameAttribute("fuelid", "Fuel", "id", Relation.OneToOne)]
		public Fuel Fuel { get; set; }

        [SqlFieldNameAttribute("engineid", "EngineStage", "id", Relation.OneToMany, "getStagesByEngineID")]
        public List<EngineStage> Stages { get; set; }

        [SqlFieldNameAttribute("url")]
        public string Url { get; set; }

        [SqlFieldNameAttribute("torqRpm")]
        public int TorqRpm { get; set; }

        [SqlFieldNameAttribute("ksRpm")]
        public int KsRpm { get; set; }


		public Engine()
		{

		}

		public Engine(string name, int capacity, int torq, int powerkw, int powerks, int maxspeed, Fuel fuel, int id, List<EngineStage> stages, string url)
		{
		    this.Name = name;
		    this.Capacity = capacity;
		    this.Torq = torq;
		    this.PowerKw = powerkw;
		    this.PowerKs = powerks;
		    this.MaxSpeed = maxspeed;
		    this.Fuel = fuel;
			this.ID = id;
            this.Stages = stages;
            this.Url = url;
		}
	}
}