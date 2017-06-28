using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public partial class Product
    {
        /// <summary>
        /// Krijg een lijst van alle producten welke niet verwijderd zijn.
        /// </summary>
        public void getFullList()
        {
            DatabaseAccess db = new DatabaseAccess();

            //db.SearchProducts.IsDeleted();

            
            //test
        }
    }
}