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

        /// <summary>
        /// vraagt het news item op uit de database
        /// past het item aan
        /// geeft aan de context door dat er iets is veranderd
        /// slaat het aangepaste news item op in de database
        /// </summary>
        /// <param name="historyId">primairy key voor database</param>
        /// <param name="versionId">primairy key voor database</param>
        [Author("Xavier van Egdom", "Nieuws goedkeuren")]
        public void Approve(int historyId, int versionId)
        {
            using(Casusblok5Model db = new Casusblok5Model())
            {
                News newsToUpdate = db.News.Where(n => n.HistoryID.Equals(historyId) 
                    && n.Version.Equals(versionId)).Single();

                newsToUpdate.IsApproved = true;

                db.News.Add(newsToUpdate);
                db.Entry(newsToUpdate).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// vraagt het "oude" nieuws item op
        /// maakt een nieuw news item aan
        /// slaat deze op in de database
        /// </summary>
        /// <param name="historyId"></param>
        /// <param name="versionId"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="approved"></param>
        /// <param name="authorId"></param>
        [Author("Xavier van Egdom", "Nieuws bewerken")]
        public void UpdateNews(int historyId, int versionId, string title, 
            string description, bool approved, int authorId)
        {
            using (Casusblok5Model db = new Casusblok5Model())
            {
                News oldNews = db.News.Where(n => n.HistoryID.Equals(historyId) &&
                n.Version.Equals(versionId)).Single();

                News newNews = new News()
                {
                    HistoryID = historyId,
                    Version = versionId++,
                    Author = db.Users.Where(u => u.ID.Equals(authorId)).Single(),
                    Title = title,
                    Description = description,
                    DueDate = oldNews.DueDate,
                    IsApproved = approved,
                    IsDeleted = false,
                };

                db.News.Add(newNews);
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