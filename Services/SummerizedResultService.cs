using Entities;
using Repository;
using Repository.Contracts;
using Services.Abstractions;

namespace Services
{
    public class SummerizedResultService :ISummerizedResultService
    {
        
        private readonly ISummerizedResultRepository summerizedResultRepository;
        public SummerizedResultService(ISummerizedResultRepository summerizedResultRepository)
        {
            this.summerizedResultRepository = summerizedResultRepository;
        }

        public SummerizedResult Get(int roll)
        {
            return this.summerizedResultRepository.GetByRoll(roll);
        }

        public IEnumerable<SummerizedResult> GetAll()
        {
            return this.summerizedResultRepository.GetAll();
        }
        public int Insert(SummerizedResult result)
        {
            return this.summerizedResultRepository.Insert(result);
        }

        //public void Update(SummerizedResult t)
        //{
        //    this.genericRepository.Update(t);
        //}
        //public void Delete(SummerizedResult t)
        //{
        //    this.genericRepository.Delete(t.Roll);
        //}
    }
}