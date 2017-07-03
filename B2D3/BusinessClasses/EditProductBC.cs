using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data;
using System.Diagnostics;
using System.Data.Entity;
using System.Linq;
using System.Web;
using B2D3.GlobalClasses;

namespace B2D3.Classes
{
    
    public partial class Product
    {
        /// <summary>
        /// Get all products where isdeleted = False
        /// </summary>
        /// <returns></returns>
        [Author("Robin Jongen", "ProductAanpassen", Version = 0.1f)]
        public DataTable CheckProduct()
        {
            var pqm = new ProductQuerryModel() { IsDeleted = false };
            var resultSet = ControlClasses.SearchProduct.QuerryProducts(pqm);
            return resultSet;
        }
        /// <summary>
        /// Get the product information with the specified ID and version
        /// </summary>
        /// <param name="ID1"></param>
        /// ID from the product
        /// <param name="Version"></param>
        /// Version form the product
        /// <returns></returns>
        [Author("Robin Jongen", "ProductAanpassen", Version = 0.1f)]
        public DataTable CheckSingleProduct(int ID1, int Version)
        {
            var pqm = new ProductQuerryModel() { ID = ID1, IsDeleted = false };
            var resultSet = ControlClasses.SearchProduct.QuerryProducts(pqm);
            return resultSet;
        }
        /// <summary>
        /// Controlleren of de data in orde is.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="Operations"></param>
        /// <param name="Specifications"></param>
        /// <param name="Length"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Weight"></param>
        /// <param name="Requirements"></param>
        /// <param name="Price"></param>
        /// <param name="Image_1"></param>
        /// <param name="Video"></param>
        /// <param name="Availability"></param>
        /// <param name="UserManual"></param>
        /// <returns></returns>
        [Author("Robin Jongen", "ProductAanpassen", Version = 0.1f)]
        public List<bool> ControlData(string Name, string Description, List<string> Operations, string Specifications, string Length, string Width, string Height, string Weight, string Requirements, string Price, string Image_1, string Video, string Availability, string UserManual)
        {
            List<bool> ControlResults = new List<bool>();

            if (Name.Length > 0 && Name.Length <= 100)
            {
                ControlResults.Add(true);
            }
            else
            {
                ControlResults.Add(false);
            }

            if (Description.Length > 0 && Description.Length <= 5000)
            {
                ControlResults.Add(true);
            }
            else
            {
                ControlResults.Add(false);
            }

            if (Operations.Count > 0)
            {
                ControlResults.Add(true);
            }
            else
            {
                ControlResults.Add(false);
            }

            if (Specifications.Length > 0 && Specifications.Length <= 1000)
            {
                ControlResults.Add(true);
            }
            else
            {
                ControlResults.Add(false);
            }

            if (Length.Length > 0 && Length.Length <= 10)
            {
                foreach (char c in Length)
                {
                    if (c < '0' || c > '9')
                    {
                        ControlResults.Add(false);
                    }
                    else
                    {
                        ControlResults.Add(true);
                    }
                }
            }

            if (Width.Length > 0 && Width.Length <= 10)
            {
                foreach (char c in Width)
                {
                    if (c < '0' || c > '9')
                    {
                        ControlResults.Add(false);
                    }
                    else
                    {
                        ControlResults.Add(true);
                    }
                }
            }

            if (Height.Length > 0 && Height.Length <= 10)
            {
                foreach (char c in Height)
                {
                    if (c < '0' || c > '9')
                    {
                        ControlResults.Add(false);
                    }
                    else
                    {
                        ControlResults.Add(true);
                    }
                }
            }

            if (Weight.Length > 0 && Weight.Length <= 10)
            {
                foreach (char c in Height)
                {
                    if (c < '0' || c > '9')
                    {
                        ControlResults.Add(false);
                    }
                    else
                    {
                        ControlResults.Add(true);
                    }
                }
            }

            if (Requirements.Length > 0 && Requirements.Length <= 1000)
            {
                ControlResults.Add(true);
            }
            else
            {
                ControlResults.Add(false);
            }

            if (Price.Length > 0 && Price.Length <= 10)
            {
                foreach (char c in Price)
                {
                    if (c < '0' || c > '9')
                    {
                        ControlResults.Add(false);
                    }
                    else
                    {
                        ControlResults.Add(true);
                    }
                }
            }

            if (Image_1.Length > 0 && Image_1.Length <= 100)
            {
                ControlResults.Add(true);
            }
            else
            {
                ControlResults.Add(false);
            }

            if (Video.Length > 0 && Video.Length <= 100)
            {
                ControlResults.Add(true);
            }
            else
            {
                ControlResults.Add(false);
            }

            if (Availability.Length > 0 && Availability.Length <= 100)
            {
                ControlResults.Add(true);
            }
            else
            {
                ControlResults.Add(false);
            }

            if (UserManual.Length > 0 && UserManual.Length <= 100)
            {
                ControlResults.Add(true);
            }
            else
            {
                ControlResults.Add(false);
            }

            return ControlResults;
        }
        /// <summary>
        /// Zet alle  data om van strings naar de juiste VAR om te sturen naar de database.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Description"></param>
        /// <param name="Operations"></param>
        /// <param name="Category"></param>
        /// <param name="Specifications"></param>
        /// <param name="Length"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Weight"></param>
        /// <param name="Requirements"></param>
        /// <param name="Price"></param>
        /// <param name="Compensation"></param>
        /// <param name="Image_1"></param>
        /// <param name="Video"></param>
        /// <param name="Availability"></param>
        /// <param name="UserManual"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Author("Robin Jongen", "ProductAanpassen", Version = 0.1f)]
        public string ConvertData(string Name, string Description, List<string> Operations, string Category, string Specifications, string Length, string Width, string Height, string Weight, string Requirements, string Price, string Compensation, string Image_1, string Video, string Availability, string UserManual, int ID)
        {
            int HistoryID = ID;                                             //ID van product
            int Version = GetMaxVers(ID)+1;                                 //Version + 1 Want dit moet de nieuwste worden
            string ProductName = Name;                                      //Name
            string ProductDescription = Description;                        //Description
            DateTime ExpirationDate = DateTime.Now.AddMonths(12);           //Expiration Date
            int TimesViewed = 0;                                            //TimesViewed
            List<int> OperationAreaIDs = new List<int>();                   //Operation Areas
            int ProductCategory = 0;                                        //ProductCategory
            List<string> ProductSpecifications = new List<string>();        //Specifications
            List<int> Dimensions = new List<int>() { Convert.ToInt32(Length), Convert.ToInt32(Width), Convert.ToInt32(Height) };                         //Dimensions TBD
            int ProductWeight = Convert.ToInt32(Weight);                    //Weight
            List<string> ProductRequirements = new List<string>();          //Requirements
            decimal ProductPrice = Convert.ToDecimal(Price);                //Price
            bool Approved = false;                                          //Approved
            bool ProductCompensation = false;                               //Compensation
            List<string> ProductImages = new List<string>() { Image_1 };    //Images
            string ProductVideo = Video;                                    //Video
            string ProductAvailability = Availability;                      //Availability
            string ProductManual = UserManual;                              //UserManual

            // Hierin staan alle operaaties, dit is een lijst in de DB
            foreach (string value in Operations)
            {
                if (value == "Eten en Drinken")
                {
                    OperationAreaIDs.Add(1);
                }
                if (value == "Wassen en Drogen")
                {
                    OperationAreaIDs.Add(2);
                }
                if (value == "Toiletgang")
                {
                    OperationAreaIDs.Add(3);
                }
                if (value == "Slepen en Rust")
                {
                    OperationAreaIDs.Add(4);
                }
                if (value == "Medicatie")
                {
                    OperationAreaIDs.Add(5);
                }
                if (value == "Huishouden")
                {
                    OperationAreaIDs.Add(6);
                }
                if (value == "Maaltijden Verzorgen")
                {
                    OperationAreaIDs.Add(7);
                }
                if (value == "Boodschappen")
                {
                    OperationAreaIDs.Add(8);
                }
                if (value == "Veilig Wonen")
                {
                    OperationAreaIDs.Add(9);
                }
                if (value == "Woning Bedienen")
                {
                    OperationAreaIDs.Add(10);
                }
                if (value == "Tranfers")
                {
                    OperationAreaIDs.Add(11);
                }
                if (value == "Verplaatsen")
                {
                    OperationAreaIDs.Add(12);
                }
                if (value == "Communicatie")
                {
                    OperationAreaIDs.Add(13);
                }
                if (value == "Vrijetijd en Ontspanning")
                {
                    OperationAreaIDs.Add(14);
                }
                if (value == "Plannen en Organiseren")
                {
                    OperationAreaIDs.Add(15);
                }
            }

            if (Category == "Apps en Software")
            {
                ProductCategory = 1;
            }
            if (Category == "Domotica")
            {
                ProductCategory = 2;
            }
            if (Category == "Service Robots")
            {
                ProductCategory = 3;
            }
            if (Category == "Sociale Robots")
            {
                ProductCategory = 4;
            }
            if (Category == "Huishoudsrobots")
            {
                ProductCategory = 5;
            }
            if (Category == "Wearables")
            {
                ProductCategory = 6;
            }
            if (Category == "Zorg op Afstand en eHealth")
            {
                ProductCategory = 7;
            }

            if (Compensation == "Vergoeding")
            {
                ProductCompensation = true;
            }
            else
            {
                ProductCompensation = false;
            }

            ProductSpecifications = Specifications.Split('-').ToList<string>();
            ProductSpecifications.Reverse();

            ProductRequirements = Requirements.Split('-').ToList<string>();
            ProductRequirements.Reverse();
            //Importen naar de DB
            string Success = EditProduct(HistoryID, Version, ProductName, ProductDescription, ExpirationDate, TimesViewed, ProductCompensation, ProductPrice, Approved, ProductCategory, OperationAreaIDs, ProductWeight, ProductVideo, ProductManual, Dimensions, ProductImages, ProductRequirements, ProductSpecifications);
            return Success;
        }
        /// <summary>
        /// Functie om de laatste versie van het meegegeven product te zoeken
        /// </summary>
        /// <returns>Max versie van het gegeven product</returns>
        [Author("Robin Jongen", "ProductAanpassen", Version = 0.1f)]
        private int GetMaxVers(int ID)
        {
            using (Casusblok5Model context = new Casusblok5Model())
            {
                IQueryable<History> histories = context.History;
                var versies = (
                    from h in histories
                    where (h.HistoryID == ID)
                    select h.Version);

                int test = versies.Max();
                return test;
            }
        }
        /// <summary>
        /// Zet alle items om van Var naar object, Het is mij bekend dat dit eerder had kunnen gebeuren. Dit is wegens tijd niet gebeurt,
        /// ik had bij Checksingleproduct een object moeten maken welke ik had kunnen gebruiken iedere keer als de BC class zou komen.
        /// Bij het aanpassen zou ik zijn values aan moeten passen en naar de DB meten pushen, wat onderstaand dus gebeurt alleen dan eerder.
        /// </summary>
        /// <param name="HistoryID"></param>
        /// <param name="Version"></param>
        /// <param name="Name"></param>
        /// <param name="Information"></param>
        /// <param name="ExpirationDate"></param>
        /// <param name="TimesViewed"></param>
        /// <param name="IsCompensated"></param>
        /// <param name="Price"></param>
        /// <param name="IsApproved"></param>
        /// <param name="Category"></param>
        /// <param name="ProductOperationAreas"></param>
        /// <param name="Weight"></param>
        /// <param name="VideoURL"></param>
        /// <param name="UserGuideURL"></param>
        /// <param name="Dimensions"></param>
        /// <param name="Picture"></param>
        /// <param name="Demands"></param>
        /// <param name="Specifications"></param>
        /// <returns></returns>
        [Author("Robin Jongen", "ProductAanpassen", Version = 0.1f)]
        public string EditProduct(int HistoryID, int Version, string Name, string Information, DateTime ExpirationDate, int TimesViewed, bool IsCompensated, decimal Price, bool IsApproved, int Category, List<int> ProductOperationAreas, float Weight, string VideoURL, string UserGuideURL, List<int> Dimensions, List<string> Picture, List<string> Demands, List<string> Specifications)
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
                product.HistoryID = HistoryID;
                product.Dimension = dimension;
                product.Version = Version;
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

                string Succes = "Product Aangepast";
                return Succes;
            }
        }
    }
}
