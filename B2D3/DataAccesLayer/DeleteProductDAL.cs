using B2D3.Classes;
using B2D3.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace B2D3.Domain
{
    [Author("Rowan Koenen", "Product Verwijderen", Version = 1)]
    public class DeleteProductDAL
    {
        public bool DeleteProduct(string name)
        {
            //using database
            using (var db = new Casusblok5Model())
            {
                //fetch products where name matches
                var products = (from p in db.Products
                                where p.Name == name
                                select p).FirstOrDefault();

                if (products != null)
                {
                    products.Dimension = db.Dimension.FirstOrDefault();
                    products.Author = db.Users.Include(b => b.AccountRole).FirstOrDefault(); 
                    products.IsDeleted = true;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                        {
                            // Get entry

                            DbEntityEntry entry = item.Entry;
                            string entityTypeName = entry.Entity.GetType().Name;

                            // Display or log error messages

                            foreach (DbValidationError subItem in item.ValidationErrors)
                            {
                                string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                         subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                                Debug.WriteLine(message);
                            }
                        }
                    }

                    return true;
                }

                else return false;
            }

            /*//using database
            using (var db = new Casusblok5Model())
            {
                //fetch products if name exists
                var products = (from p in db.Products
                                where p.Name == name
                                select p);

                //double check if any product exists
                if (products.Any())
                {
                    //change attribute "IsDeleted" from false to true
                    foreach (var prod in products)
                    {
                        prod.IsDeleted = false;
                    }

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                Debug.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                    }

                    return true;
                }

                else
                {
                    return false;
                }
            }*/
        }
    }
}