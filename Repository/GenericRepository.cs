using Dapper;
using Entities.Utilities;
using Repository.Contracts;
using System.Data.SqlClient;

namespace Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly SqlConnection Connection;
        private SqlTransaction transaction;
        public GenericRepository()
        {
            this.Connection = new SqlConnection(Constants.DefaultConnectionString);
        }

        public SqlConnection GetSqlConnection()
        {
            if (Connection.State != System.Data.ConnectionState.Open)
                Connection.Open();
            return Connection;
        }

        public TEntity Get<TEntity>(string query, object o)
        {
            return Connection.Query<TEntity>(query, o).FirstOrDefault();
        }
        public bool Check(string query, object o)
        {
            return Connection.Query<bool>(query, o).FirstOrDefault();
        }
        public int InsertAndGetPkey<TEntity>(string query, TEntity entity)
        {
            dynamic id;
            int primaryKeyValue = 0;
            id = Connection.Query(query, entity, transaction: transaction).FirstOrDefault();
            primaryKeyValue = GetPrimaryKeyValue(id);
            return primaryKeyValue;
        }



        public IEnumerable<TEntity> GetAll<TEntity>(string query, object o = null)
        {
            if (o == null)
            {
                return Connection.Query<TEntity>(query, transaction: transaction);
            }
            return Connection.Query<TEntity>(query, o, transaction: transaction);
        }

        public int Insert<TEntity>(string query, TEntity entity)
        {
            dynamic id;
            int primaryKeyValue = 0;

            id = transaction != null
                ? Connection.Query(query, entity, transaction: transaction).FirstOrDefault()
                : Connection.Query(query, entity).FirstOrDefault();
            primaryKeyValue = GetPrimaryKeyValue(id);
            return primaryKeyValue;
        }

        public void Executor(string query, object o)
        {
            Connection.Execute(query, o, transaction: transaction);
        }
        public void Update<TEntity>(string query, object o)
        {
            Connection.Execute(query, o, transaction: transaction);
        }

        public void SetTransction(SqlTransaction transaction)
        {
            this.transaction = transaction;
        }
        public IEnumerable<TEntity> GetJoiningTwoModel<TEntiy1, TEntiy2, TEntity>(string query, Func<TEntiy1, TEntiy2, TEntity> map, object ob, string splitOn)
        {
            return Connection.Query<TEntiy1, TEntiy2, TEntity>(query, map, ob, splitOn: splitOn);

        }

        public int GetPrimaryKeyValue(dynamic id)
        {
            if (id == null)
                return 0;
            else
            {
                var pk = 0;
                var firstItem = (IDictionary<string, object>)id;
                foreach (var v in firstItem)
                {
                    pk = Convert.ToInt32(v.Value);
                }
                return pk;
            }
        }
    }
}

