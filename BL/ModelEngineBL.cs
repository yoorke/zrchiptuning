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
	public class ModelEngineBL
	{
		public List<BE.ModelEngine> GetAll()
		{
            return new ModelEngineRepository().GetAll();
		}

		public int Save(BE.ModelEngine modelengine)
		{
			ModelEngineRepository repository = new ModelEngineRepository();
			if(modelengine.ID > 0)
				return repository.Update(modelengine);
			else
				return repository.Insert(modelengine);
		}

		public bool Delete(BE.ModelEngine modelengine)
		{
            return new ModelEngineRepository().Delete(modelengine);
		}

		public BE.ModelEngine GetModelEngine(int id)
		{
            return new ModelEngineRepository().GetByID(id);
		}
	}
}