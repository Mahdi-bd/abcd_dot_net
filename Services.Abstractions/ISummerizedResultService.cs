using Entities;

namespace Services.Abstractions
{
    public interface ISummerizedResultService
    {
        SummerizedResult Get(int roll);
        IEnumerable<SummerizedResult> GetAll();
        int Insert(SummerizedResult result);
    }
}