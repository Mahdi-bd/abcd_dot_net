using Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class BaseService : IDisposable
    {
       
        public SqlConnection Connection { get; set; }
        public SqlTransaction Transaction { get; set; }
        public BaseService()
        {
            Connection = new SqlConnection(Constants.DefaultConnectionString);
            //if (Connection.State != System.Data.ConnectionState.Open)
            //{
            //    try
            //    {
            //        Connection.Open();
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception(ex.Message);
            //        throw new Exception("Failed to connect with database. please contact with system administrator.");
            //    }
            //}
        }

        public void Dispose()
        {
        }
    }
}
