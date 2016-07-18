using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryInterfaces;
using BE;
using DAL;
using System.Collections.Generic;
using System.Data;

namespace Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository()
        {

        }
        
        //public void Create(User entity)
        //{
        //    using (IDBManager dbManager = new DBManager(DataProvider.SqlServer))
        //    {
        //        dbManager.Open();

        //        dbManager.Parameters = new GenericMapper().AttachParameters<User>("usp_KorisnikInsert", entity);

        //        dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "usp_KorisnikInsert");
        //    }
        //}

        

        //public void Delete(Int32 id)
        //{

        //}

        //public void Delete(User entity)
        //{

        //}

        //public User Get(Int32 id)
        //{
        //    User user = null;
        //    using (IDBManager dbManager = new DBManager(DataProvider.SqlServer))
        //    {
        //        dbManager.Open();

        //        dbManager.CreateParameters(1);
        //        dbManager.AddParameters(0, "@id", id);

                
        //        IDataReader reader = dbManager.ExecuteReader(System.Data.CommandType.StoredProcedure, "usp_KorisnikSelect");
        //        while (reader.Read())
        //        {
        //            if (user == null)
        //                user = new User();
        //            user = new GenericMapper().Map<User>(reader);
        //        }

        //    }
        //    return user;
        //}

        //public void Update(User entity)
        //{

        //}
    }
}
