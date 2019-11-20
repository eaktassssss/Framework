using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.DataAccess.EntityFramework
{
    public interface IRepository<T>
    where T : class, new()
    {
        /*
         * Burada ihtiyaçlarımıza göre genişletebiliriz.
         */
        void Delete(T entity);
        IQueryable<T> GetList();
        IQueryable<T> GetList(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
