using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B2D3.UI
{
    public partial class Occasion_Overzicht : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            //cancel the operation and return to main page
            Response.Redirect("~/default.aspx");
        }
    }
}