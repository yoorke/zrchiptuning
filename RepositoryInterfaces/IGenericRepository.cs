using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;

namespace RepositoryInterfaces
{
    public interface IGenericRepository<T>
    {
        int Insert(T entity);
        int Update(T entity);
        bool Delete(T entity);
        T GetByID(object id);
        List<T> GetAll(QueryOptions queryOptions);
        List<T> GetByParameter(string action, List<QueryParameter> parameters, bool isLazy);
        DataTable GetDataTable(string storedProcedureName, string action, List<QueryParameter> parameters);
    }
}
