using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace BE
{
	public class EngineStage : BaseEntity
	{
		//[SqlFieldNameAttribute("engineid", "Engine", "id", Relation.OneToOne)]
		//public Engine Engine { get; set; }

		[SqlFieldNameAttribute("stageid", "Stage", "id", Relation.OneToOne)]
		public Stage Stage { get; set; }

		[SqlFieldNameAttribute("torq")]
		public int Torq { get; set; }

        [SqlFieldNameAttribute("torqRpm")]
        public int TorqRpm { get; set; }

		[SqlFieldNameAttribute("powerks")]
		public int PowerKs { get; set; }

		[SqlFieldNameAttribute("powerkw")]
		public int PowerKw { get; set; }

        [SqlFieldNameAttribute("ksRpm")]
        public int PowerKsRpm { get; set; }

		[SqlFieldNameAttribute("maxspeed")]
		public int MaxSpeed { get; set; }

        [SqlFieldNameAttribute("engineID")]
        public int EngineID { get; set; }


		public EngineStage()
		{

		}

		public EngineStage(Engine engine, Stage stage, int torq, int powerks, int powerkw, int maxspeed, int id)
		{
		    //this.Engine = engine;
		    this.Stage = stage;
		    this.Torq = torq;
		    this.PowerKs = powerks;
		    this.PowerKw = powerkw;
		    this.MaxSpeed = maxspeed;
			this.ID = id;
		}
	}
}