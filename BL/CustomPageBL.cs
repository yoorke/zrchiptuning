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
	public class CustomPageBL
	{
		public List<BE.CustomPage> GetAll()
		{
            return new CustomPageRepository().GetAll();
		}

		public int Save(BE.CustomPage custompage)
		{
			CustomPageRepository repository = new CustomPageRepository();
            if (custompage.ID > 0)
            {
                repository.Update(custompage);
                return custompage.ID;
            }
            else
                return repository.Insert(custompage);
		}

		public bool Delete(BE.CustomPage custompage)
		{
            return new CustomPageRepository().Delete(custompage);
		}

		public BE.CustomPage GetCustomPage(int id)
		{
            return new CustomPageRepository().GetByID(id);
		}

        public CustomPage GetCustomPage(string url)
        {
            List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("url", url));

            List<CustomPage> customPages = new CustomPageRepository().GetByParameter("getByUrl", parameters);
            return customPages.Count > 0 ? customPages[0] : null;
        }
	}
}