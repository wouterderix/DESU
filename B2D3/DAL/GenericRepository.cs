using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using B2D3.DAL;

namespace B2D3.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private bool _isDisposed;
        protected DbContext Context
        { get; private set; }
        internal DbSet<T> DbSet;


        public GenericRepository(DbContext context)
        {
            if (context == null)
            { throw new NullReferenceException("DbContext may not be null!"); }
            Context = context;

            DbSet = Context.Set<T>();
        }
        ~GenericRepository()
        { Context?.Dispose(); }

        public virtual IEnumerable<T> Search(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            { query = query.Where(filter); }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            { query = query.Include(includeProperty); }

            if (orderBy != null)
            { return orderBy(query).ToList(); }
            else
            { return query.ToList(); }
        }
        public virtual T Single(params object[] primaryKeys)
        { return FindByID(primaryKeys); }
        public virtual T SingleOrDefault(params object[] primaryKeys)
        { return FindByID(primaryKeys); }
        public virtual bool Exists(params object[] primaryKeys)
        { return FindByID(primaryKeys) != null; }
        public virtual T FindByID(params object[] primaryKeys)
        { return DbSet.Find(primaryKeys); }
        public virtual void Insert(T entity)
        { DbSet.Add(entity); }
        public virtual void Delete(params object[] primaryKeys)
        {
            Delete(FindByID(primaryKeys));
        }
        public virtual void Delete(T entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }
        public virtual void Update(T entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }
        public virtual void Persist()
        { Context.SaveChanges(); }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                { Context.Dispose(); }
            }
            _isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}