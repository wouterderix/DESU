using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace B2D3.DAL
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> Search(
    Expression<Func<T, bool>> filter = null,
    Func<IQueryable<T>,
    IOrderedQueryable<T>> orderBy = null,
    string includeProperties = "");
        IEnumerable<T> GetAll();
        T Single(params object[] primaryKeys);
        T SingleOrDefault(params object[] primaryKeys);
        bool Exists(params object[] primaryKeys);
        T FindByID(params object[] primaryKeys);
        void Insert(T entity);
        void Delete(params object[] primaryKeys);
        void Delete(T entityToDelete);
        void Update(T entityToUpdate);
        void Persist();
    }
}