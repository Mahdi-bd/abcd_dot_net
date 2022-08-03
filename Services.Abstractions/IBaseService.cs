using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IBaseService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Insert(T t);
        void Update(T t);
        void Delete(T t);
    }
}
