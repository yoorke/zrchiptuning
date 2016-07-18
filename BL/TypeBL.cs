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
	public class TypeBL
	{
		public List<BE.Type> GetAll(bool addSelect)
		{
            return (addSelect) ? getEmpty(new TypeRepository().GetAll()) : new TypeRepository().GetAll();
		}

        private List<BE.Type> getEmpty(List<BE.Type> types)
        {
            types.Insert(0, new BE.Type("Odaberi", -1, "Odaberi"));
            return types;
        }

		public int Save(BE.Type type)
		{
			TypeRepository repository = new TypeRepository();
			if(type.ID > 0)
				return repository.Update(type);
			else
				return repository.Insert(type);
		}

		public bool Delete(BE.Type type)
		{
            return new TypeRepository().Delete(type);
		}

		public BE.Type GetType(int id)
		{
            return new TypeRepository().GetByID(id);
		}

        public BE.Type GetTypeByUrl(string url)
        {
            List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("url", url));
            List<BE.Type> types = new TypeRepository().GetByParameter("getByUrl", parameters);
            return types.Count > 0 ? types[0] : null;
        }
	}
}