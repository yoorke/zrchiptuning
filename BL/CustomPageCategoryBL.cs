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
	public class CustomPageCategoryBL
	{
		public List<BE.CustomPageCategory> GetAll()
		{
            return new CustomPageCategoryRepository().GetAll();
		}

		public int Save(BE.CustomPageCategory custompagecategory)
		{
			CustomPageCategoryRepository repository = new CustomPageCategoryRepository();
			if(custompagecategory.ID > 0)
				return repository.Update(custompagecategory);
			else
				return repository.Insert(custompagecategory);
		}

		public bool Delete(BE.CustomPageCategory custompagecategory)
		{
            return new CustomPageCategoryRepository().Delete(custompagecategory);
		}

		public BE.CustomPageCategory GetCustomPageCategory(int id)
		{
            return new CustomPageCategoryRepository().GetByID(id);
		}
	}
}