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
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //atabase.SetInitializer(new DropCreateDatabaseAlways<Casusblok5Model>());

            //using (var db = new Casusblok5Model())
            //{
            //    db.Category.Add(new Category() { Name = "Categorie1" });
            //    db.SaveChanges();
            //}
        }
    }
}