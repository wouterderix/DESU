using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using B2D3.Classes;
using B2D3.GlobalClasses;

namespace B2D3.Classes.CC
{
    public class ControlProductDataCC
    {
        [Author("Nigel Croese", "ProductZoeken", Version = 1)]
        CreateProduct CP = new CreateProduct();

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

        [Author("Wouter Derix", "ProductZoeken", Version = 1)]
        public string ConvertData(string Name, string Description, List<string> Operations, string Category, string Specifications, string Length, string Width, string Height, string Weight, string Requirements, string Price, string Compensation, string Image_1, string Video, string Availability, string UserManual)
        {
            int Version = 1;                                                //Version
            string ProductName = Name;                                      //Name
            string ProductDescription = Description;                        //Description
            DateTime ExpirationDate = DateTime.Now.AddMonths(12);           //Expiration Date
            int TimesViewed = 0;                                            //TimesViewed
            List<int> OperationAreaIDs = new List<int>();                   //Operation Areas
            int ProductCategory = 0;                                        //ProductCategory
            List<string> ProductSpecifications = new List<string>();        //Specifications
            List<int> Dimensions = new List<int>() { Convert.ToInt32(Length), Convert.ToInt32(Width), Convert.ToInt32(Height)};                         //Dimensions TBD
            int ProductWeight = Convert.ToInt32(Weight);                    //Weight
            List<string> ProductRequirements = new List<string>();          //Requirements
            decimal ProductPrice = Convert.ToDecimal(Price);                //Price
            bool Approved = false;                                          //Approved
            bool ProductCompensation = false;                               //Compensation
            List<string> ProductImages = new List<string>() { Image_1 };    //Images
            string ProductVideo = Video;                                    //Video
            string ProductAvailability = Availability;                      //Availability
            string ProductManual = UserManual;                              //UserManual


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

            string Success = CP.AddProduct(Version, ProductName, ProductDescription, ExpirationDate, TimesViewed, ProductCompensation, ProductPrice, Approved, ProductCategory, OperationAreaIDs, ProductWeight, ProductVideo, ProductManual, Dimensions, ProductImages, ProductRequirements, ProductSpecifications);
            return Success;
        }
    }
}