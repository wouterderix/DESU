using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;
using B2D3.GlobalClasses;

namespace B2D3.Classes
{
    [Author("Thom Kemp", "Houdbaarheidsdatum Controleren", Version = 1)]
    public partial class CheckDateBC
    {
        // Define DataTable
        private static DataTable dt;

        /// <summary>
        /// Generate Array of query results
        /// </summary>
        /// <returns>Returned fields in Array: ModifyID, VersionID, DimensionID, Name, Information, Category, Supplier, ExpDate</returns>
        public Array CheckDate()
        {
            using (Casusblok5Model context = new Casusblok5Model())
            {
                IQueryable<Product> products = context.Products;

                var productArray = (
                    from p in products
                    where p.ExpirationDate <= DateTime.Now && p.IsDeleted == false
                    select new { ModifyID = p.HistoryID, VersionID = p.Version, DimensionID = p.Dimension.Id, Name = p.Name, Information = p.Information, Category = p.ProductCategory.Name, Supplier = p.Supplier.Name, ExpDate = p.ExpirationDate }
                    ).ToArray();

                return productArray;
            }
        }

        /// <summary>
        /// Generates the DataTable according to the Array generated in CheckDate()
        /// </summary>
        /// <returns>Returns the generated DataTable</returns>
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

        /// <summary>
        /// Deletes the product selected on the input form
        /// </summary>
        /// <param name="id">HistoryID given on the input form</param>
        /// <param name="vid">Version given on the input form</param>
        /// <param name="dim">DimensionID given on the input form</param>
        /// <returns>Product is succesvol verwijderd</returns>
        public string DeleteByID(int id, int vid, int dim)
        {
            using (Casusblok5Model db = new Casusblok5Model())
            {
                Product prod;
                prod = db.Products.Where(p => p.HistoryID == id && p.Version == vid).FirstOrDefault<Product>();
                User user;
                user = db.Users.FirstOrDefault<User>();
                Dimension dimension;
                dimension = db.Dimension.Where(d => d.Id == dim).FirstOrDefault<Dimension>();
                if (prod != null)
                {
                    prod.Version = vid;
                    prod.HistoryID = id;
                    prod.Dimension = dimension;
                    prod.Author = user;
                    prod.IsDeleted = true;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                        {
                            DbEntityEntry entry = item.Entry;
                            string entityTypeName = entry.Entity.GetType().Name;

                            foreach (DbValidationError subItem in item.ValidationErrors)
                            {
                                string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                         subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                                Debug.WriteLine(message);
                            }
                        }
                    }
                }
            }

            return "Product is succesvol verwijderd";

        }

        /// <summary>
        /// Modifies the product selected on the input form
        /// </summary>
        /// <param name="id">HistoryID given on the input form</param>
        /// <param name="vid">Version given on the input form</param>
        /// <param name="dim">DimensionID given on the input form</param>
        /// <param name="date">Date selected on the date picker on the input form</param>
        /// <returns>Product is succesvol bijgewerkt</returns>
        public string ModifyByID(int id, int vid, int dim, DateTime date)
        {
            using (Casusblok5Model db = new Casusblok5Model())
            {
                Product prod;
                prod = db.Products.Where(p => p.HistoryID == id && p.Version == vid).FirstOrDefault<Product>();
                User user;
                user = db.Users.FirstOrDefault<User>();
                Dimension dimension;
                dimension = db.Dimension.Where(d => d.Id == dim).FirstOrDefault<Dimension>();
                if (prod != null)
                {
                    prod.Version = vid;
                    prod.HistoryID = id;
                    prod.Dimension = dimension;
                    prod.Author = user;
                    prod.IsDeleted = false;
                    prod.ExpirationDate = date;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                        {
                            DbEntityEntry entry = item.Entry;
                            string entityTypeName = entry.Entity.GetType().Name;

                            foreach (DbValidationError subItem in item.ValidationErrors)
                            {
                                string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                         subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                                Debug.WriteLine(message);
                            }
                        }
                    }
                }
            }

            return "Product is succesvol bijgewerkt";
        }
    }
}