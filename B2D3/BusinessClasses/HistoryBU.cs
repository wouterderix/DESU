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
        private static DataTable dt;

        public List<Array> GetData(DateTime StartDate)
        {
            using (Casusblok5Model context = new Casusblok5Model())
            {
                IQueryable<History> histories = context.History;
                IQueryable<Product> products = context.Products;
                IQueryable<Occasion> occasions = context.Occasions;
                IQueryable<News> news = context.News;

                var productHistoryArray = (
                    from p in products
                    where ( p.LogDate > StartDate)
                    select new
                    {
                        ID = p.HistoryID,
                        Version = p.Version,
                        Data = p.Name+ ", " + p.Information,
                        LogDate = p.LogDate,
                        
                    }
                    ).ToArray();

                // Alle history van occasion ophalen
                var occasionHistoryArray = (
                    from o in occasions
                    where (o.LogDate > StartDate)
                    orderby o.LogDate
                    select new
                    {
                        ID = o.HistoryID,
                        Version = o.Version,
                        Data = o.Title,
                        LogDate = o.LogDate,
                    }).ToArray();


                // Alle history van news ophalen
                var newsHistoryArray = (
                    from n in news
                    where (n.LogDate > StartDate)
                    orderby n.LogDate
                    select new
                    {
                        ID = n.HistoryID,
                        Version = n.Version,
                        Data = n.Title,
                        LogDate = n.LogDate,
                    }).ToArray();

                Debug.WriteLine(productHistoryArray);
                List<Array> test = new List<Array>();

                test.Add(productHistoryArray);
                test.Add(newsHistoryArray);
                test.Add(occasionHistoryArray);

                
                return(test);
            }
        }

        public DataSet ReturnData(DateTime StartDate)
        {
            HistoryBU h = new HistoryBU();

            DataSet dsHistory = new DataSet();
            DataTable dtProduct = new DataTable("Products");
            DataTable dtNews = new DataTable("News");
            DataTable dtOccasions = new DataTable("Occasions");

            //Array history;
            //history = h.GetData(StartDate);

            List<Array> historyDataArray = new List<Array>();
            historyDataArray = h.GetData(StartDate);

            dsHistory.Tables.Add(dtProduct);
            dsHistory.Tables.Add(dtOccasions);
            dsHistory.Tables.Add(dtNews);

            for (int i = 0; i < historyDataArray.Count; i++)
            {
                for (int j = 0; j < historyDataArray[i].Length; j++)
                {
                    Dictionary<string, object> dict = DataDictProperties.DictionaryFromType(historyDataArray[i].GetValue(j));
                    if (j == 0)
                    {
                        foreach (KeyValuePair<String, object> kvp in dict)
                        {
                            dsHistory.Tables[i].Columns.Add(kvp.Key);    // Kolomen benoemen 
                        }
                    }
                    DataRow dr = dtProduct.NewRow();
                    foreach (KeyValuePair<String, object> kvp in dict)
                    {
                        dr[kvp.Key] = kvp.Value;        // Waarden aan de kolommen toevoegen
                    }
                    dtProduct.Rows.Add(dr);
                }
            }
            return dsHistory;
        }
    }
}