using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository
    {
        public SqlConnection Connection { get; set; }
        public SqlTransaction SqlTransaction { get; set; }

        public BaseRepository(SqlConnection connection, SqlTransaction transaction = null)
        {
            Connection = connection;
            SqlTransaction = transaction;
        }
    }
}
