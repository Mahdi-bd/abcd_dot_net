using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IGenericRepository
    {
        public IEnumerable<TEntity> GetAll<TEntity>(string query, object o = null);
        public TEntity Get<TEntity>(string query, object o);
        public int Insert<TEntity>(string query, TEntity entity);
        public void Update<TEntity>(string query, object o);
        public int InsertAndGetPkey<TEntity>(string query, TEntity entity);
        public IEnumerable<TEntity> GetJoiningTwoModel<TEntiy1, TEntiy2, TEntity>(string query, Func<TEntiy1, TEntiy2, TEntity> map, object ob, string splitOn);
        public void SetTransction(SqlTransaction transaction);
        public void Executor(string query, object o);
        public bool Check(string query, object o);
        public SqlConnection GetSqlConnection();
    }
}
