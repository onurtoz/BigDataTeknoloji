using BigDataTeknoloji.Data.Entity.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BigDataTeknolojiData.Repository.GenericRepository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _dbcontext;

        protected int _process;
        protected List<T> list;

        public GenericRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public virtual int Add(T t)
        {

            _dbcontext.Set<T>().Add(t);
            _process = _dbcontext.SaveChanges();
            return _process;
        }


        public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _dbcontext.Set<T>().Where(match).ToList();
        }

        public virtual T GetSingleProperties(Func<T, bool> where, Expression<Func<T, object>> navigationProperties)
        {
            T item = null;

            IQueryable<T> queryable = _dbcontext.Set<T>();
            if (navigationProperties != null)
            {
                queryable = queryable.Include<T, object>(navigationProperties);
            }
            item = queryable.AsNoTracking().FirstOrDefault(where);

            return item;
        }
    }
}
