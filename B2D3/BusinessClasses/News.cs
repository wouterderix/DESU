using B2D3.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;


namespace B2D3.Classes
{
    [Author("Jens Koekkoek, Xavier van Egdom", "NieuwsInzien")]
    public partial class News
    {
        public DataTable SearchNews(int takeCount = 10)
        {
            using (Casusblok5Model db = new Casusblok5Model())
            {
                return GetDataTableFromNews(db.News.OrderByDescending(n => n.HistoryID).Take(takeCount).ToArray());
            }
        }

        [Author("Xavier van Egdom", "Nieuws goedkeuren")]
        public void Approve(int id)
        {
            using(Casusblok5Model db = new Casusblok5Model())
            {
                News newsToUpdate = db.News.Where(n => n.HistoryID.Equals(id)).Single();
                newsToUpdate.IsApproved = true;

                db.News.Add(newsToUpdate);
                db.Entry(newsToUpdate).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }

        public News GetNewsByID(int NewsID)
        {
            using (Casusblok5Model db = new Casusblok5Model())
            {
                return db.News.Where(n => n.HistoryID == NewsID).FirstOrDefault();
            }
        }

        public DataTable GetDataTableFromNews(Array news)
        {
            DataTable dt = new DataTable();

            for (int i = 0; i < news.Length; i++)
            {
                Dictionary<string, object> dict = DataDictProperties.DictionaryFromType(news.GetValue(i));
                if (i == 0)
                {
                    foreach (KeyValuePair<String, object> kvp in dict)
                    {
                        dt.Columns.Add(kvp.Key);
                    }
                }
                DataRow dr = dt.NewRow();
                foreach (KeyValuePair<String, object> kvp in dict)
                {
                    dr[kvp.Key] = kvp.Value;
                }

                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}