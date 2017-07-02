using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using B2D3.Classes;
using B2D3.GlobalClasses;

namespace B2D3.Classes.CC
{
    [Author("Robin Jongen", "ProductAanpassen", Version = 0.1f)]
    public class EditProductCC
    {

        Product p = new Product();

        /// <summary>
        /// Een functie om alle producten op te halen wat niet verwijdert zijn.
        /// </summary>

        public DataTable getList()
        {
            return p.CheckProduct();
        }
        public DataTable getitem(int ID, int Version)
        {
            return p.CheckSingleProduct(ID,Version);
        }
        /// <summary>
        /// Een functie om alle input uit de UI te controlleren in de BC laag
        /// </summary>
        public List<bool> ControlData(string name, string description, List<string> operationAreas, string specifications, string length, string width, string height, string weight, string requirements, string price, string image_1, string video, string availability, string userManual)
        {
            return p.ControlData( name,  description,  operationAreas,  specifications,  length,  width,  height,  weight,  requirements,  price,  image_1,  video,  availability,  userManual);
        }
        /// <summary>
        /// Een functie om alle data te converteren voor import naar DB
        /// </summary>
        public string ConvertData(string name, string description, List<string> operationAreas, string category, string specifications, string length, string width, string height, string weight, string requirements, string price, string compensation, string image_1, string video, string availability, string userManual,int ID)
        {
            return p.ConvertData(name, description, operationAreas, category, specifications, length, width, height, weight, requirements, price,compensation, image_1, video, availability, userManual, ID);

        }
    }
}