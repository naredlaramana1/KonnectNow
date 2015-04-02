using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KonnectNow.Repository.EF
{
    public interface IDomainRepository<T> where T : class
    {
        IEnumerable<T> Get(
               Expression<Func<T, bool>> filter = null,
               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
               string includeProperties = "");

        T GetByID(object id);

        dynamic Insert(T entity);


        void Delete(object id);


        void Delete(T entityToDelete);

        void Update(T entityToUpdate);

    }
    
}
