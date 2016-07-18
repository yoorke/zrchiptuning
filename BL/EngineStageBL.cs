using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using BE;
using System.Data;
using System.Web.Security;

namespace BL
{
	public class EngineStageBL
	{
		public List<BE.EngineStage> GetAll()
		{
            return new EngineStageRepository().GetAll();
		}

		public int Save(BE.EngineStage enginestage)
		{
			EngineStageRepository repository = new EngineStageRepository();
			if(enginestage.ID > 0)
				return repository.Update(enginestage);
			else
				return repository.Insert(enginestage);
		}

		public bool Delete(BE.EngineStage enginestage)
		{
            return new EngineStageRepository().Delete(enginestage);
		}

		public BE.EngineStage GetEngineStage(int id)
		{
            return new EngineStageRepository().GetByID(id);
		}
	}
}