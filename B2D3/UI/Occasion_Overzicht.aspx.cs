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
            if (Request.QueryString["NewOccasion"] == "True")
            {
                New_Occasion.Text = "Nieuwe Occasion succesvol toegevoegd";
            }
        }
        protected void btn_Back_Click(object sender, EventArgs e)
        {
            //Cancel the operation and return to main page
            Response.Redirect("~/default.aspx");
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the AllOccasionsView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void AllOccasionsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the selected Row and then get the HistoryID of that Row
            GridViewRow row = AllOccasionsView.SelectedRow;
            string historyID = AllOccasionsView.SelectedDataKey.Value.ToString();
            //Redirect to Occasion Edit view, with HistoryID as parameter
            Response.Redirect("/UI/Occasion_Bewerken.aspx?HistoryID="+historyID);
        }
    }
}