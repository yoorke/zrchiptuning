using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryInterfaces;
using DAL;
using System.Data;
using Utility.ExceptionHandling;
using BE;

namespace Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        public virtual int Insert(T entity)
        {
            int status = 0;
            string spName = new Common().GetSpName(entity.GetType().Name.ToLower(), "insert");
            using (IDBManager dbManager = new DBManager(DataProvider.SqlServer))
            {
                try
                {
                    dbManager.Open();
                    dbManager.Parameters = new GenericMapper().AttachParameters<T>(spName, entity);
                    //dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, spName);
                    using (IDataReader reader = dbManager.ExecuteReader(CommandType.StoredProcedure, spName))
                    {
                        while (reader.Read())
                            status = int.Parse(reader["id"].ToString());
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new DLException("Error occured while inserting data to: " + entity.GetType().Name, ex);
                }
            }
            return status;
        }

        public virtual int Update(T entity)
        {
            int status = 0;
            string spName = new Common().GetSpName(entity.GetType().Name.ToLower(), "update");
            using (IDBManager dbManager = new DBManager(DataProvider.SqlServer))
            {
                try
                {
                    dbManager.Open();
                    dbManager.Parameters = new GenericMapper().AttachParameters<T>(spName, entity);
                    dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, spName);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new DLException("Error occured while updating data to: " + entity.GetType().Name, ex);
                }
            }
            return status;
        }

        public virtual bool Delete(T entity)
        {
            int status = 0;
            string spName = new Common().GetSpName(entity.GetType().Name.ToLower(), "delete");
            using (IDBManager dbManager = new DBManager(DataProvider.SqlServer))
            {
                try
                {
                    dbManager.Open();
                    dbManager.Parameters = new GenericMapper().AttachParameters<T>(spName, entity);
                    //status = dbManager.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, spName);
                    //status = int.Parse(dbManager.ExecuteScalar(System.Data.CommandType.StoredProcedure, spName).ToString());
                    //status = true;
                    using (IDataReader reader = dbManager.ExecuteReader(CommandType.StoredProcedure, spName))
                    {
                        while (reader.Read())
                            status = reader.GetInt32(0);
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new DLException("Error occured while deleting: " + entity.GetType().Name, ex);
                }
            }
            return status > 0;
        }

        public virtual T GetByID(object id)
        {
            T entity = Activator.CreateInstance<T>();
            string spName = new Common().GetSpName(entity.GetType().Name.ToLower(), "select");
            using (IDBManager dbManager = new DBManager(DataProvider.SqlServer))
            {
                try
                {
                    dbManager.Open();
                    dbManager.CreateParameters(1);
                    dbManager.AddParameters(0, "@id", id);

                    using (IDataReader reader = dbManager.ExecuteReader(CommandType.StoredProcedure, spName))
                    {
                        while (reader.Read())
                            entity = new GenericMapper().Map<T>(reader, false);
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new DLException("Error occured while loading data from database: " + entity.GetType().Name + ", id: " + id.ToString(), ex);
                }
            }
            return entity;            
        }

        public virtual List<T> GetAll(QueryOptions queryOptions = null)
        {
            List<T> items = null;
            items = new List<T>();
            T entity = Activator.CreateInstance<T>();
            string spName = new Common().GetSpName(entity.GetType().Name.ToLower(), "get");
            using (IDBManager dbManager = new DBManager(DataProvider.SqlServer))
            {
                try
                {
                    dbManager.Open();

                    using (IDataReader reader = dbManager.ExecuteReader(CommandType.StoredProcedure, spName))
                    {
                        while (reader.Read())
                        {
                            if (items == null)
                                items = new List<T>();
                            entity = new GenericMapper().Map<T>(reader);
                            items.Add(entity);
                        }
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new DLException("Error while loading data from database: " + entity.GetType().Name, ex);
                }
            }
            return items;
        }

        public virtual List<T> GetByParameter(string action, List<QueryParameter> parameters, bool isLazy = true)
        {
            List<T> items = null;
            items = new List<T>();
            T entity = Activator.CreateInstance<T>();
            string spName = new Common().GetSpName(entity.GetType().Name.ToLower(), action);
            using (IDBManager dbManager = new DBManager(DataProvider.SqlServer))
            {
                try
                {
                    dbManager.Open();
                    dbManager.Parameters = new GenericMapper().AttachParameters(spName, parameters);
                    using (IDataReader reader = dbManager.ExecuteReader(CommandType.StoredProcedure, spName))
                    {
                        while (reader.Read())
                        {
                            if (items == null)
                                items = new List<T>();
                            entity = new GenericMapper().Map<T>(reader, isLazy);
                            items.Add(entity);
                        }
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new DLException("Error while loading data. Action: " + action + ". Store procedure: " + spName, ex);
                }
            }
            return items;
        }

        public virtual DataTable GetDataTable(string className, string action, List<QueryParameter> parameters)
        {
            DataTable dataTable = new DataTable();
            string spName = new Common().GetSpName(className, action);
            using (IDBManager dbManager = new DBManager(DataProvider.SqlServer))
            {
                try
                {
                    dbManager.Open();
                    if(parameters != null)
                        dbManager.Parameters = new GenericMapper().AttachParameters(spName, parameters);
                    using (IDataReader reader = dbManager.ExecuteReader(CommandType.StoredProcedure, spName))
                    {
                        dataTable = new DataTable();
                        dataTable.Load(reader);
                    }
                }
                catch(System.Data.SqlClient.SqlException ex)
                {
                    throw new DLException("Error while loading data to data table. Action: " + action + ". Class name: " + className, ex);
                }
            }
            return dataTable;
        }

        public virtual int ExecuteAction(string className, string action, List<QueryParameter> parameters)
        {
            int status = 0;
            string spName = new Common().GetSpName(className, action);
            using (IDBManager dbManager = new DBManager(DataProvider.SqlServer))
            {
                try
                {
                    dbManager.Open();
                    dbManager.Parameters = new GenericMapper().AttachParameters(spName, parameters);
                    status = dbManager.ExecuteNonQuery(CommandType.StoredProcedure, spName);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new DLException("Error while executing store procedure : " + spName, ex);
                }
            }
            return status;
        }
    }
}
