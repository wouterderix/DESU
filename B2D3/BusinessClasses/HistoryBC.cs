using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using B2D3.Classes;
using System.Diagnostics;
using B2D3.GlobalClasses;

namespace B2D3.Classes
{
    [Author("Yannic van de kuit & Ramon Cremers", "Audit Log", Version = 1.0f)]
    public partial class HistoryBC
    {
        /// <summary>
        /// GetData() haalt de data uit de database en zet deze in een array
        /// Huidige query laat alleen zien dat er data uit de database gehaald wordt.
        /// </summary>
        public List<Array> GetData(DateTime StartDate)
        {
            using (Casusblok5Model context = new Casusblok5Model())
            {
                IQueryable<History> histories = context.History;
                IQueryable<Product> products = context.Products;
                IQueryable<Occasion> occasions = context.Occasions;
                IQueryable<News> news = context.News;

                // Alle history van product ophalen
                var productHistoryArray = (
                    from p in products
                    where ( p.LogDate >= StartDate)
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
                    where (o.LogDate >= StartDate)
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
                    where (n.LogDate >= StartDate)
                    orderby n.LogDate
                    select new
                    {
                        ID = n.HistoryID,
                        Version = n.Version,
                        Data = n.Title,
                        LogDate = n.LogDate,
                    }).ToArray();

                Debug.WriteLine(productHistoryArray);

                //List met Array voor het returnen van meerdere arrays.
                List<Array> HistroyArray = new List<Array>();
                HistroyArray.Add(productHistoryArray);
                HistroyArray.Add(newsHistoryArray);
                HistroyArray.Add(occasionHistoryArray);          
                     
                return(HistroyArray);
            }
        }


        public DataTable ReturnData(DateTime StartDate)
        {

            ///<summary>
            /// Data wordt opgevraagd door middel van GetData() methode
            /// Deze data wordt in een DataTable gezet en terug gestuurd naar de CC laag
            /// </summary>
            HistoryBC h = new HistoryBC();
            DataTable dtHistory = new DataTable("History");
            List<Array> historyDataArray = new List<Array>();
            historyDataArray = h.GetData(StartDate);

            for (int i = 0; i < historyDataArray.Count; i++)
            {
                for (int j = 0; j < historyDataArray[i].Length; j++)
                {
                    Dictionary<string, object> dict = DataDictProperties.DictionaryFromType(historyDataArray[i].GetValue(j));
                    if (dtHistory.Columns.Count == 0)
                    {
                        foreach (KeyValuePair<String, object> kvp in dict)
                        {
                            dtHistory.Columns.Add(kvp.Key);    // Kolomen benoemen 
                        }
                    }
                    DataRow dr = dtHistory.NewRow();
                    foreach (KeyValuePair<String, object> kvp in dict)
                    {
                        dr[kvp.Key] = kvp.Value;        // Waarden aan de kolommen toevoegen
                    }
                    dtHistory.Rows.Add(dr);
                }
            }
            return dtHistory;
        }
    }
}