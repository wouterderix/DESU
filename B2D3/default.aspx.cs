using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
<<<<<<< HEAD
using B2D3.Classes.CC;
=======
using B2D3.ControlClasses;
>>>>>>> refs/remotes/origin/master2

namespace B2D3
{

    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            GridView1.DataSource = SearchProduct.GetAllProducts();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            var controller = new OccasionGet();
            Debug.WriteLine(controller.getAllOccasions());
            
        }

        protected void btn_newEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UI/Occasion_Toevoegen.aspx");
        }

        protected void btn_allEvents_Click1(object sender, EventArgs e)
        {
            Response.Redirect("/UI/Occasion_Overzicht.aspx");
        }
=======
            
        } 
>>>>>>> refs/remotes/origin/master
=======
            GridView1.DataSource = SearchProduct.SearchByName("rolstoel");
        }
>>>>>>> refs/remotes/origin/master2
    }
}