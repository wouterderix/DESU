﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using B2D3.Classes;
using B2D3.GlobalClasses;

namespace B2D3.Classes.CC
{
    
    public class EditProductCC
    {

        Product p = new Product();

        /// <summary>
        /// Een functie om alle producten op te halen wat niet verwijdert zijn.
        /// </summary>
        [Author("Robin Jongen", "ProductAanpassen", Version = 0.1f)]
        public DataTable getList()
        {
            return p.CheckProduct();
        }
        /// <summary>
        /// krijg een datatable met de info van een product, dit zou een object kunnen zijn, ivm tijd met bob besloten dit niet op te pakken.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Version"></param>
        /// <returns></returns>
        [Author("Robin Jongen", "ProductAanpassen", Version = 0.1f)]
        public DataTable getitem(int ID, int Version)
        {
            return p.CheckSingleProduct(ID,Version);
        }
        /// <summary>
        /// Een functie om alle input uit de UI te controlleren in de BC laag
        /// </summary>
        [Author("Robin Jongen", "ProductAanpassen", Version = 0.1f)]
        public List<bool> ControlData(string name, string description, List<string> operationAreas, string specifications, string length, string width, string height, string weight, string requirements, string price, string image_1, string video, string availability, string userManual)
        {
            return p.ControlData( name,  description,  operationAreas,  specifications,  length,  width,  height,  weight,  requirements,  price,  image_1,  video,  availability,  userManual);
        }
        /// <summary>
        /// Een functie om alle data te converteren voor import naar DB
        /// </summary>
        [Author("Robin Jongen", "ProductAanpassen", Version = 0.1f)]
        public string ConvertData(string name, string description, List<string> operationAreas, string category, string specifications, string length, string width, string height, string weight, string requirements, string price, string compensation, string image_1, string video, string availability, string userManual,int ID)
        {
            return p.ConvertData(name, description, operationAreas, category, specifications, length, width, height, weight, requirements, price,compensation, image_1, video, availability, userManual, ID);

        }
    }
}