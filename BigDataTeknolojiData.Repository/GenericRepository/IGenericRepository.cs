using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BigDataTeknolojiData.Repository.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {

        int Add(T t);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match);
        T GetSingleProperties(Func<T, bool> where, Expression<Func<T, object>> navigationProperties);

    }
}
