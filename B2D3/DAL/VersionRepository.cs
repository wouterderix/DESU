using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using B2D3.Classes;

namespace B2D3.DAL
{
    public abstract class VersionRepository<T> : GenericRepository<T>, IVersionRepository<T> where T : History
    {
        public VersionRepository(DbContext context) : base(context)
        { }

        public virtual T FindLatestByID(int historyID)
        { return DbSet.Where(x => x.HistoryID == historyID).OrderByDescending(x => x.Version).FirstOrDefault(); }
        public virtual IQueryable<T> GetAllLatest()
        {
            return DbSet.GroupBy(p => p.HistoryID)
                    .Select(v => v.OrderByDescending(p => p.Version).FirstOrDefault());
        }
    }
}