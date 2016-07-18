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
	public class FuelBL
	{
		public List<BE.Fuel> GetAll()
		{
            return new FuelRepository().GetAll();
		}

		public int Save(BE.Fuel fuel)
		{
			FuelRepository repository = new FuelRepository();
			if(fuel.ID > 0)
				return repository.Update(fuel);
			else
				return repository.Insert(fuel);
		}

		public bool Delete(BE.Fuel fuel)
		{
            return new FuelRepository().Delete(fuel);
		}

		public BE.Fuel GetFuel(int id)
		{
            return new FuelRepository().GetByID(id);
		}
	}
}