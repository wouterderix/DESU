using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;

namespace B2D3
{

    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var controller = new OccasionGet();
            Debug.WriteLine(controller.getAllOccasions());
        }

        protected void BtnBewerkItems_Click(object sender, EventArgs e)
        {
            var o = new OccasionBewerken();
            o.DoorgeefID(1);

            Response.Redirect("/UI/Occasion_Bewerken.aspx");
        }
    }
}