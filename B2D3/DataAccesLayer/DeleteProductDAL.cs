using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace B2D3.Domain
{
    /// <summary>
    /// behoort tot UC Product verwijderen
    /// gemaakt door Rowan Koenen
    /// </summary>

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
                    products.IsDeleted = true;

                    try
                    {
                        db.SaveChanges();
                    }

                    catch (Exception exception)
                    {
                        throw exception;
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