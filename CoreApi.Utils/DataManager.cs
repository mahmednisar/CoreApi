using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CoreApi.Utils
{ 

    /// <summary>
    /// For Creating ADO.Net Methods  --
    /// DataSet
    /// DataTable
    /// </summary>
    public  class DataManager
    {
        public DataManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly  IConfiguration _configuration;


        public DataSet GetDataSet( string procedure, List<Parameters> parametersList)
        {
            var dataset = new DataSet();
            var cmd = new SqlCommand(procedure, new SqlConnection(_configuration.GetConnectionString("conn")))
            { CommandType = CommandType.StoredProcedure, CommandTimeout = 0 };

            foreach (var par in parametersList)
            {
                cmd.Parameters.AddWithValue("@"+par.Name, par.Value);
            }

            var da = new SqlDataAdapter(cmd);
            da.Fill(dataset);
            return dataset;
        }
        public DataTable GetDataTable( string Query)
        {
            var datable = new DataTable();
            var cmd = new SqlCommand(Query, new SqlConnection(_configuration.GetConnectionString("conn")))
            {  CommandTimeout = 0 };
            var da = new SqlDataAdapter(cmd);
            da.Fill(datable);
            return datable;
        }
        
    }

    public class Parameters
    {
        public string  Name{ get; set; }
        public object Value{ get; set; }
    }
}
