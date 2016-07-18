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
	public class ManufacturerBL
	{
		public List<BE.Manufacturer> GetAll()
		{
            return new ManufacturerRepository().GetAll();
		}

		public int Save(BE.Manufacturer manufacturer)
		{
			ManufacturerRepository repository = new ManufacturerRepository();
			if(manufacturer.ID > 0)
				return repository.Update(manufacturer);
			else
				return repository.Insert(manufacturer);
		}

		public bool Delete(BE.Manufacturer manufacturer)
		{
            return new ManufacturerRepository().Delete(manufacturer);
		}

		public BE.Manufacturer GetManufacturer(int id)
		{
            return new ManufacturerRepository().GetByID(id);
		}

        public List<Manufacturer> GetByType(string typeUrl, bool addSelect)
        {
            List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("typeUrl", typeUrl));
            return (addSelect) ? getEmpty(new ManufacturerRepository().GetByParameter("getByType", parameters)) : new ManufacturerRepository().GetByParameter("getByType", parameters);
        }

        public Manufacturer GetManufacturer(string url)
        {
            List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("url", url));
            List<Manufacturer> manufacturers = new ManufacturerRepository().GetByParameter("getByUrl", parameters);
            return manufacturers.Count > 0 ? manufacturers[0] : null;
        }

        public List<Manufacturer> GetByTypeID(int typeID, bool addSelect)
        {
            List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("typeID", typeID));
            return (addSelect) ? getEmpty(new ManufacturerRepository().GetByParameter("getByTypeID", parameters)) : new ManufacturerRepository().GetByParameter("getByTypeID", parameters);
        }

        private List<Manufacturer> getEmpty(List<Manufacturer> manufacturers)
        {
            if (manufacturers != null)
            {
                manufacturers.Insert(0, new Manufacturer("Odaberi", -1, string.Empty, "Odaberi"));
            }
            return manufacturers;
        }
	}
}