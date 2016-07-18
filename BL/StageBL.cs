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
	public class StageBL
	{
		public List<BE.Stage> GetAll()
		{
            return new StageRepository().GetAll();
		}

		public int Save(BE.Stage stage)
		{
			StageRepository repository = new StageRepository();
			if(stage.ID > 0)
				return repository.Update(stage);
			else
				return repository.Insert(stage);
		}

		public bool Delete(BE.Stage stage)
		{
            return new StageRepository().Delete(stage);
		}

		public BE.Stage GetStage(int id)
		{
            return new StageRepository().GetByID(id);
		}
	}
}