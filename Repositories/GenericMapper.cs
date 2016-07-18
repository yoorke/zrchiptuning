using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using DAL;
using System.Data;
using BE;
using System.Web.Security;
using System.Web;

namespace Repositories
{
    public class GenericMapper
    {
        private object getCurrentValue<T>(string fieldName, T entity)
        {
            if (fieldName.Equals("_insertDate") || fieldName.Equals("_updateDate"))
                return DateTime.Now;
            else if (fieldName.Equals("_userIDInsert") || fieldName.Equals("_userIDUpdate"))
                return int.Parse(Membership.GetUser().ProviderUserKey.ToString());

            object value = null;
            PropertyInfo[] propertyInfos = entity.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetCustomAttributes(true).Count() > 0)
                {
                    string dbFieldName = (propertyInfo.GetCustomAttributes(typeof(SqlFieldNameAttribute), false).FirstOrDefault() as SqlFieldNameAttribute).SqlFieldName;
                    string sqlForeignKeyFiledName = (propertyInfo.GetCustomAttributes(typeof(SqlFieldNameAttribute), false).FirstOrDefault() as SqlFieldNameAttribute).SqlForeignKeyFieldName;
                    string sqlForeignClassName = (propertyInfo.GetCustomAttributes(typeof(SqlFieldNameAttribute), false).FirstOrDefault() as SqlFieldNameAttribute).SqlForeignClassName;

                    if (sqlForeignClassName != string.Empty && sqlForeignKeyFiledName != string.Empty && fieldName.ToLower().Equals(dbFieldName.ToLower()))
                    {
                        var foreignClass = propertyInfo.GetValue(entity, null);
                        value = (foreignClass != null) ? getCurrentValue(sqlForeignKeyFiledName, foreignClass) : null;
                        break;
                    }
                    else
                        if (fieldName.ToLower().Equals(dbFieldName.ToLower()))
                        {
                            value = propertyInfo.GetValue(entity, null);
                            break;
                        }
                }
            }
            return value;
        }

        public IDbDataParameter[] AttachParameters<T>(string spName, T entity)
        {
            List<Parameter> spParameters = new Parameters().GetParametersForStoredProcedure(spName);

            IDbDataParameter[] parameters = new IDbDataParameter[spParameters.Count];
            parameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, spParameters.Count);

            int index = 0;
            foreach (Parameter spParameter in spParameters)
            {
                parameters[index].ParameterName = spParameter.Name;
                //((System.Data.SqlClient.SqlParameter)parameters[index]).SqlDbType = GetDbType(spParameter.DataType);
                parameters[index++].Value = getCurrentValue(spParameter.Name.Replace("@", ""), entity);                              
            }
            return parameters;
        }

        public IDbDataParameter[] AttachParameters(string spName, List<QueryParameter> queryParameters)
        {
            List<Parameter> spParameters = new Parameters().GetParametersForStoredProcedure(spName);
            IDbDataParameter[] parameters = new IDbDataParameter[spParameters.Count];
            parameters = DBManagerFactory.GetParameters(DataProvider.SqlServer, spParameters.Count);

            int index = 0;
            foreach (Parameter spParameter in spParameters)
            {
                parameters[index].ParameterName = spParameter.Name;
                parameters[index++].Value = (from QueryParameter queryParameter in queryParameters
                                             where queryParameter.Name.ToLower().Equals(spParameter.Name.Replace("@","").ToLower())
                                             select queryParameter.Value).First();
            }
            return parameters;
        }

        public T Map<T>(IDataRecord record, bool isLazy = true)
        {
            T entity = Activator.CreateInstance<T>();

            PropertyInfo[] propertyInfos = entity.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetCustomAttributes(true).Count() > 0)
                {
                    string sqlFieldName = (propertyInfo.GetCustomAttributes(typeof(SqlFieldNameAttribute), false).FirstOrDefault() as SqlFieldNameAttribute).SqlFieldName;
                    string sqlForeignKeyFieldName = (propertyInfo.GetCustomAttributes(typeof(SqlFieldNameAttribute), false).FirstOrDefault() as SqlFieldNameAttribute).SqlForeignKeyFieldName;
                    string sqlForeignClassName = (propertyInfo.GetCustomAttributes(typeof(SqlFieldNameAttribute), false).FirstOrDefault() as SqlFieldNameAttribute).SqlForeignClassName;
                    Relation relation = (propertyInfo.GetCustomAttributes(typeof(SqlFieldNameAttribute), false).FirstOrDefault() as SqlFieldNameAttribute).SqlRelation;

                    if (sqlForeignKeyFieldName != string.Empty && sqlForeignClassName != string.Empty)
                    {
                        System.Type foreignClassType = System.Type.GetType("BE." + sqlForeignClassName + ", BE");
                        if (isLazy && relation == Relation.OneToOne)
                        {
                            dynamic foreignClass = Activator.CreateInstance(foreignClassType);
                            foreignClass.ID = record[sqlFieldName].GetType() != typeof(System.DBNull) ? (int)record[sqlFieldName] : -1;
                            propertyInfo.SetValue(entity, foreignClass);
                        }
                        else if (relation == Relation.OneToOne)
                        {
                            var repository = typeof(GenericRepository<>).MakeGenericType(foreignClassType);
                            dynamic repositoryInstance = Activator.CreateInstance(repository);
                            propertyInfo.SetValue(entity, (repositoryInstance).GetByID(record[sqlFieldName]));
                        }
                        else if (!isLazy && relation == Relation.OneToMany)
                        {
                            var repository = typeof(GenericRepository<>).MakeGenericType(foreignClassType);
                            dynamic repositoryInstance = Activator.CreateInstance(repository);
                            string action = (propertyInfo.GetCustomAttributes(typeof(SqlFieldNameAttribute), false).FirstOrDefault() as SqlFieldNameAttribute).Action;
                            List<QueryParameter> parameters = new List<QueryParameter>();
                            parameters.Add(new QueryParameter(sqlFieldName, record["ID"]));
                            propertyInfo.SetValue(entity, (repositoryInstance).GetByParameter(action, parameters, false));
                        }
                        else if(isLazy && relation == Relation.OneToMany)
                        {
                            propertyInfo.SetValue(entity, null);
                        }
                        
                        //var instanceProperty = repository.GetProperty("Instance");
                        //dynamic instance = instanceProperty.GetValue(null, null);
                    }
                    else
                    {
                        if (record[sqlFieldName] == DBNull.Value)
                        {
                            System.Type t = record[sqlFieldName].GetType();
                            propertyInfo.SetValue(entity, default(dynamic), null);
                        }
                        else
                            propertyInfo.SetValue(entity, record[sqlFieldName], null);
                    }
                }

                
            }

            return entity;
        }

        private SqlDbType GetDbType(string type)
        {
            switch (type)
            {
                case "smalldatetime": return SqlDbType.SmallDateTime;
                case "int": return SqlDbType.Int;
                case "nvarchar": return SqlDbType.NVarChar;
                case "smallint": return SqlDbType.SmallInt;
                case "date": return SqlDbType.Date;
                case "decimal": return SqlDbType.Decimal;
                case "bit": return SqlDbType.Bit;
            }
            return SqlDbType.NVarChar;
        }
    }
}
