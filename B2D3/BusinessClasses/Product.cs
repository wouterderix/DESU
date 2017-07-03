using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public partial class Product
    {

        public DataTable GetAllProductNotApproved()
        {
            using (Casusblok5Model db = new Casusblok5Model())
            {
                var product = (from p in db.Products
                               where p.IsApproved.Equals(false)
                               select p).ToArray();

                DataTable dtProducts = GetDataTableFromProduct(product);
                return dtProducts;
            }
        }

        //using(Casusblok5Model db = new Casusblok5Model())
        //{
        //    return GetDataTableFromNews(db.Products.Where(p => p.IsApproved.Equals(false)).ToArray());
        //}



        public DataTable GetDataTableFromProduct(Array product)
        {
            DataTable dt = new DataTable();

            for (int i = 0; i < product.Length; i++)
            {
                Dictionary<string, object> dict = DataDictProperties.DictionaryFromType(product.GetValue(i));
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

        public bool Approve(int historyID, int versionID)
        {
            using (Casusblok5Model db = new Casusblok5Model())
            {
                Product productToUpdate = db.Products.Where(n => n.HistoryID.Equals(historyID) && n.Version.Equals(versionID)).Single();
                productToUpdate.IsApproved = true;
                productToUpdate.Dimension = db.Dimension.FirstOrDefault();
                productToUpdate.Author = db.Users.Include(b => b.AccountRole).FirstOrDefault();

                try
                {
                    db.SaveChanges();
                    //noError
                    return true;
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }

                    return false;
                }
            }
        }
    }
}