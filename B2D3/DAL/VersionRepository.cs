using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using B2D3.Classes;

namespace B2D3.DAL
{
    public class VersionRepository<T> : GenericRepository<T>, IVersionRepository<T> where T : History
    {
        public VersionRepository(DbContext context) : base(context)
        { }

        public virtual T FindLatestByID(int historyID)
        { return DbSet.Where(x => x.HistoryID == historyID).OrderByDescending(x => x.Version).FirstOrDefault(); }

        [Obsolete("Throws an SQL error. Avoid unless you can fix!", false)]
        public virtual IEnumerable<T> GetAllLatest()
        {
            return DbSet.GroupBy(p => p.HistoryID)
                    .Select(v => v.OrderByDescending(p => p.Version).FirstOrDefault());
        }
        public virtual IEnumerable<T> GetAllLatestBad()
        {
            List<T> latestVersions = DbSet.ToList();
            latestVersions = latestVersions.GroupBy(p => p.HistoryID)
                .Select(v => v.OrderByDescending(p => p.Version).FirstOrDefault()).ToList();
            return latestVersions;
        }
        public virtual Tid GetNextID<Tid>() where Tid : struct
        {
            return (Tid)Convert.ChangeType(DbSet.Max(x => x.HistoryID) + 1, typeof(Tid));
        }
        public virtual Tid GetNextVersion<Tid>(T history) where Tid : struct
        {
            return (Tid)Convert.ChangeType(DbSet.Where(x => x.HistoryID == history.HistoryID).Max(x => x.Version), typeof(Tid));
        }
    }
}