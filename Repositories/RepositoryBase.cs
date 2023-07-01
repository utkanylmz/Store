using Microsoft.EntityFrameworkCore;
using Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class,new()
    {
        protected readonly RepositoryContext context;

        protected RepositoryBase(RepositoryContext context)
        {
            this.context = context;
        }

        public void Create(T entity)
        {
           context.Set<T>().Add(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? context.Set<T>()
                                : context.Set<T>().AsNoTracking();     
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ?
                             context.Set<T>().Where(expression).SingleOrDefault()
                           : context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity); 
        }
    }
}
