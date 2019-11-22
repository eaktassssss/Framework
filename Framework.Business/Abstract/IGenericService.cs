using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Business.Abstract
{
    public interface IGenericService<T> where T:class,new()
    {
        void Delete(T entity);
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
