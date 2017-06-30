using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;

namespace B2D3.Classes.UI
{
    public partial class Occasion_Overzicht : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OccasionGet occasionGet = new OccasionGet();
            List<Occasion> occasions = occasionGet.getAllOccasions();

            AllOccasionsView.DataSource = occasions;
            AllOccasionsView.DataBind();
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            //cancel the operation and return to main page
            Response.Redirect("~/default.aspx");
        }

        protected void AllOccasionsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = AllOccasionsView.SelectedRow;
            string historyID = AllOccasionsView.SelectedDataKey.Value.ToString();
            Response.Redirect("/UI/Occasion_Bewerken.aspx?HistoryID="+historyID);
        }
    }
}