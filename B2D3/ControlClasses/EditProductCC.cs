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
    }
}