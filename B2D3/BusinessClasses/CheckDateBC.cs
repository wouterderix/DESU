using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace B2D3.Classes
{
    public partial class CheckDateBC
    {
        private static DataTable dt;

        public Array CheckDate()
        {
            using (Casusblok5Model context = new Casusblok5Model())
            {
                IQueryable<Product> products = context.Products;

                var productArray = (
                    from p in products
                    where p.ExpirationDate <= DateTime.Now && p.IsDeleted == false
                    select new { ID = p.HistoryID, Name = p.Name, Information = p.Information, Category = p.ProductCategory, ExpDate = p.ExpirationDate }).ToArray();

                return productArray;
            }
        }

        public DataTable ReturnDates()
        {
            CheckDateBC p = new CheckDateBC();
            Array productArray;
            productArray = p.CheckDate();

            dt = new DataTable();

            for (int i = 0; i < productArray.Length; i++)
            {
                Dictionary<string, object> dict = DataDictProperties.DictionaryFromType(productArray.GetValue(i));
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

        public string DeleteByID(int id)
        {
            Product prod;
            using (Casusblok5Model db = new Casusblok5Model()) {
                prod = db.Products.Where(p => p.HistoryID == id).FirstOrDefault<Product>();
            }

            if (prod != null)
            {
                prod.IsDeleted = true;
            }

            using (Casusblok5Model dbNew = new Casusblok5Model())
            {
                //3. Mark entity as modified
                dbNew.Entry(prod).State = System.Data.Entity.EntityState.Modified;

                //4. call SaveChanges
                dbNew.SaveChanges();
            }

            return "Product is succesvol verwijderd";
        }

        public string ModifyByID(int id, DateTime date)
        {
            Product prod;
            using (Casusblok5Model db = new Casusblok5Model())
            {
                prod = db.Products.Where(p => p.HistoryID == id).FirstOrDefault<Product>();
            }

            if (prod != null)
            {
                prod.IsDeleted = false;
                prod.ExpirationDate = date;
            }

            using (Casusblok5Model dbNew = new Casusblok5Model())
            {
                //3. Mark entity as modified
                dbNew.Entry(prod).State = System.Data.Entity.EntityState.Modified;

                //4. call SaveChanges
                dbNew.SaveChanges();
            }

            return "Product is succesvol bijgewerkt!";
        }
    }
}