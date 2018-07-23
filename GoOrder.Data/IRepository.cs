using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoOrder.Data
{
    public interface IRepository<T> where T : Entity
    {
        void Delete(Expression<Func<T, bool>> filter);
        void Delete(object id);
        void Delete(T entityToDelete);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", bool isTrackingOff = false);
        IEnumerable<T> GetAll(out int total, out int totalDisplay, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
        T GetByID(object id, string includeProperties = "");
        int GetCount(Expression<Func<T, bool>> filter = null);
        IEnumerable<T> GetDynamic(Expression<Func<T, bool>> filter = null, string orderBy = null, string includeProperties = "", bool isTrackingOff = false);
        IEnumerable<T> GetDynamic(out int total, out int totalDisplay, Expression<Func<T, bool>> filter = null, string orderBy = null, string includeProperties = "", int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
        void Add(T entity);
        void Update(T entityToUpdate);
    }
}
