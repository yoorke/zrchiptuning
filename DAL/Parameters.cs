using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Utility.ExceptionHandling;

namespace DAL
{
    public class Parameter
    {
        public int OrdinalPosition { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public int MaxLength { get; set; }

        public Parameter(int ordinalPosition, string name, string dataType, int maxLength)
        {
            this.OrdinalPosition = ordinalPosition;
            this.Name = name;
            this.DataType = dataType;
            this.MaxLength = maxLength;
        }
    }

    public class Parameters
    {
        public List<Parameter> GetParametersForStoredProcedure(string storedProcedureName)
        {
            List<Parameter> parameters = null;
            using (IDBManager dbManager = new DBManager(DataProvider.SqlServer))
            {
                try
                {
                    dbManager.Open();
                    dbManager.CreateParameters(1);
                    dbManager.AddParameters(0, "@SPName", storedProcedureName);
                    IDataReader reader = dbManager.ExecuteReader(System.Data.CommandType.StoredProcedure, "storeProcedure_getParameters");

                    while (reader.Read())
                    {
                        if (parameters == null)
                            parameters = new List<Parameter>();
                        parameters.Add(new Parameter(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), !Convert.IsDBNull(reader[3]) ? reader.GetInt32(3) : -1));
                    }
                    //dbManager.Close();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new DLException("Could not load parameters for stored procedure: " + storedProcedureName, ex);
                }
            }
            return parameters;
        }
    }
}
