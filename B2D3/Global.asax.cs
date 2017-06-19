using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using B2D3.Classes;

namespace B2D3
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //Database.SetInitializer<Casusblok5Model>(new CreateDatabaseIfNotExists<Casusblok5Model>());

            var a = ControlClasses.SearchProduct.GetAllProducts();
        }
    }
}