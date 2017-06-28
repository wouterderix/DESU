using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using B2D3.Classes;
using System.Diagnostics;

namespace B2D3.Classes
{
    public partial class HistoryBU
    {
        //private static DataTable dt;
        ////public DataTable GetData(DateTime StartDate)
        ////{
        ////    //History h = History;
        ////    //voor alle DueDate in History tabel > StartDate - Return data
        ////    return dt;
        ////}
        ////public static List<History> SearchByDate(DateTime StartDate)
        ////{
        ////    using (var db = )
        ////}
        //public List<History> getData(DateTime StartDate)
        //{
        //    IEnumerable<History> History = new List<History>();

        //    // Get all Occasions
        //    using (var db = new Casusblok5Model())
        //    { History = db.History.ToList(); }
        //    // Group by historyID and get the latest version
        //    History = History.GroupBy(o => o.HistoryID)
        //        .Select(v => v.OrderByDescending(o => o.HistoryID).FirstOrDefault());
        //    // If showpassedevents equals false, don't show passedevents
        //    History = History.Where(o => o.LogDate  <= StartDate);

        //    return History.ToList();
        //}


        private static DataTable dt;

        //public List<History> GetDate(DateTime StartDate)

        //{
        //    using (Casusblok5Model context = new Casusblok5Model())
        //    {
        //        var user = context.History.Where(u => u.HistoryID.Equals(userID)).SingleOrDefault();

        //        if (user != null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        public Array GetData(DateTime StartDate)
        {
            using (Casusblok5Model context = new Casusblok5Model())
            {
                IQueryable<History> histories = context.History;
                IQueryable<Product> products = context.Products;
                IQueryable<Occasion> occasions = context.Occasions;
                IQueryable<News> news = context.News;

                //var productList = (from p in products
                //               select p).ToArray();

                var productHistoryArray = (
                    from h in products
                    where (h.LogDate > StartDate)
                    select new
                    {
                        ID = h.HistoryID,
                        Version = h.Version,
                        Data = h.Name,
                        LogDate = h.LogDate
                    }).ToArray();

                //var historyArray = (
                //    from h in histories
                //    where h.LogDate > StartDate
                //    select new
                //    {
                //        ID = h.HistoryID,
                //        Version = h.Version,
                //        Author = h.Author,
                //        LogDate = h.LogDate,
                //        IsDeleted = h.IsDeleted
                //    }).ToArray();
                Debug.WriteLine(productHistoryArray);
                return (productHistoryArray);
            }
        }

        public DataTable ReturnData(DateTime StartDate)
        {
            HistoryBU h = new HistoryBU();
            DataSet dsHistory = new DataSet();
            DataTable dtProduct = new DataTable("Products");
            DataTable dtNews = new DataTable("News");
            DataTable dtOccasions = new DataTable("Occasions");


            Array product;
            product = h.GetData(StartDate);

            dt = new DataTable();

            for (int i = 0; i < product.Length; i++)
            {
                Dictionary<string, object> dict = DataDictProperties.DictionaryFromType(product.GetValue(i));
                if (i == 0)
                {
                    foreach (KeyValuePair<String, object> kvp in dict)
                    {
                        dt.Columns.Add(kvp.Key);    // Kolomen benoemen 
                    }
                }
                DataRow dr = dt.NewRow();
                foreach (KeyValuePair<String, object> kvp in dict)
                {
                    dr[kvp.Key] = kvp.Value;        // Waarden aan de kolommen toevoegen
                }

                dt.Rows.Add(dr);

            }

            return dt;
        }
    }
}