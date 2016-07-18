using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using RepositoryInterfaces;

namespace Repositories
{
	public class ModelRepository : GenericRepository<BE.Model>, IModelRepository
	{
		public ModelRepository()
		{

		}
	}
}