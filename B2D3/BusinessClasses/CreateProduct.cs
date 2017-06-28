using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace B2D3.Classes
{
    public class CreateProduct
    {
        public string AddProduct(int Version, string Name, string Information, DateTime ExpirationDate, int TimesViewed, bool IsCompensated, decimal Price, bool IsApproved, int Category, List<int> ProductOperationAreas, float Weight, string VideoURL, string UserGuideURL, List<int> Dimensions, List<string> Picture, List<string> Demands, List<string> Specifications)
        {
            using (var db = new Casusblok5Model())
            {
                Dimension dimension = new B2D3.Dimension();
                var g = (from p in db.Specifications
                           select p.Id);
                int Max_GID = g.Max();
                dimension.Id = Max_GID + 1;
                dimension.Length = Dimensions[0];
                dimension.Width = Dimensions[1];
                dimension.Height = Dimensions[2];

                List<Specification> specs = new List<Specification>();
                int i = 0;
                foreach (string value in Specifications)
                {
                    Specification spec = new Specification();
                    var IDs = (from p in db.Specifications
                                select p.Id);
                    int Max_ID = IDs.Max();
                    spec.Id = Max_ID + 1;
                    spec.Description = Specifications[i];
                    specs.Add(spec);
                    db.Specifications.Add(spec);
                    i++;
                }

                List<Demands> demands = new List<Demands>();
                i = 0;
                foreach (string value in Demands)
                {
                    Demands demand = new Demands();
                    var IDs = (from p in db.Demands
                            select p.Id);
                    int Max_ID = IDs.Max();
                    demand.Id = Max_ID + 1;
                    demand.Description = value;
                    demands.Add(demand);
                    db.Demands.Add(demand);
                    i++;
                }

                Picture pic = new Picture();
                i = 0;
                foreach (string value in Picture)
                {
                    var IDs = (from p in db.Pictures
                               select p.Id);
                    int Max_ID = IDs.Max();
                    pic.Id = Max_ID + 1;
                    pic.PictureURL = Picture[i];
                    i++;
                }

                Product product = new Product();
                product.Dimension = dimension;
                product.Version = 1;
                product.Name = Name;
                product.Information = Information;
                product.ExpirationDate = ExpirationDate;
                product.TimesViewed = TimesViewed;
                product.IsCompensated = IsCompensated;
                product.Price = Price;
                product.IsApproved = IsApproved;
                var Cat = (from p in db.Category
                           where p.Id == Category
                           select p);
                product.ProductCategory = Cat.SingleOrDefault();
                product.Weight = Weight;
                product.VideoURL = VideoURL;
                product.UserGuideURL = UserGuideURL;
                product.Author = db.Users.Include(b => b.AccountRole).FirstOrDefault();
                product.Demands = demands;
                product.Specification = specs;

                List<OperationArea> OA = new List<OperationArea>();
                foreach (int value in ProductOperationAreas)
                {
                    var PC = (from p in db.OperationArea
                              where p.Id == value
                              select p);
                    OA.Add(PC.SingleOrDefault());
                }
                product.ProductOperationAreas = OA;
                try
                {
                    //Add newOccasion to Occasions
                    db.Dimension.Add(dimension);
                    db.Pictures.Add(pic);
                    db.Products.Add(product);
                    //SaveChanges to database
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

                string Succes = "Product Toegevoegd";
                return Succes;
            }
        }
    }
}