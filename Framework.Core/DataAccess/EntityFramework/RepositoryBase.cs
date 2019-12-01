using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Core.DataAccess.EntityFramework
{
    public class RepositoryBase<TContext, TEntity>: IRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        DbSet<Type> _dbSet;
        public TEntity Add(TEntity entity)
        {
            using(var context = new TContext())
            {
                var result = context.Set<TEntity>().Add(entity);
                context.SaveChanges();
                return result;
                //var result = context.Entry(entity);
                //result.State = EntityState.Added;
                //context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using(var context = new TContext())
            {
                var result = context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
                //var result = context.Entry(entity);
                //result.State = EntityState.Deleted;
                //context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using(var context = new TContext())
            {
                var entity = context.Set<TEntity>().Find(id);
                if(entity != null)
                {
                    context.Set<TEntity>().Remove(entity);
                    context.SaveChanges();
                }
            }
        }

        
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using(var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public List<TEntity> GetList()
        {
            using(var context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            using(var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using(var context = new TContext())
            {
                var result = context.Entry(entity);
                result.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
