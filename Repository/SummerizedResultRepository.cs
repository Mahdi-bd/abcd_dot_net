using Entities;
using Entities.Utilities;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SummerizedResultRepository : ISummerizedResultRepository
    {
        private readonly IGenericRepository repository;
        public SummerizedResultRepository(IGenericRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<SummerizedResult> GetAll()
        {
            string query = @"SELECT * FROM SummerizedResult";
            return this.repository.GetAll<SummerizedResult>(query);
        }

        public SummerizedResult GetByRoll(int roll)
        {
            string query = @"SELECT * FROM SummerizedResult
                             WHERE Roll = @roll";
            return this.repository.Get<SummerizedResult>(query, new { roll = roll });
        }

        public int Insert(SummerizedResult result)
        {
            string query = QB<SummerizedResult>.Insert();
            return this.repository.Insert<SummerizedResult>(query, result);
        }
    }
}
