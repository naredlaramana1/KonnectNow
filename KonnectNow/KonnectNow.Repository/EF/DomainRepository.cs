using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Repository.EF
{
    
        public class DomainRepository<T> : IDomainRepository<T> where T : class
        {
            internal KonnectNowContext context;
            internal DbSet<T> dbSet;

            public DomainRepository(KonnectNowContext context)
            {
                this.context = context;
                this.dbSet = context.Set<T>();

            }

            public IEnumerable<T> Get(
                Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = "")
            {
                IQueryable<T> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                    return query.ToList();
                }
            }

            public T GetByID(object id)
            {
                return dbSet.Find(id);
            }

            public dynamic Insert(T entity)
            {
                dynamic obj = dbSet.Add(entity);
                context.SaveChanges();
                return obj;


            }

            public void Delete(object id)
            {
                T entityToDelete = dbSet.Find(id);
                Delete(entityToDelete);
            }

            public void Delete(T entityToDelete)
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            }

            public void Update(T entityToUpdate)
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }
        }
    
}
