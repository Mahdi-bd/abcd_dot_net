using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository.Contracts
{
    public interface ISummerizedResultRepository
    {
        SummerizedResult GetByRoll(int roll);
        int Insert(SummerizedResult result);
        IEnumerable<SummerizedResult> GetAll();
    }
}