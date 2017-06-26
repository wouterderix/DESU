using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;

namespace B2D3.Classes.UI
{

    public partial class _Occasion_Bewerken : Page
    {
        /// <summary>
        /// main page event bewerken
        /// user gets page with current information of event, can edit and commit to database
        /// also used to EventToevoegen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //get event information when page gets loaded
            var o = new OccasionBewerken();
            
            TBBeschrijving.Text = (o.doorgeefID).ToString();
        }

        protected void btnBewerk_Click(object sender, EventArgs e)
        {
            //edit the currently loaded event

        }
        protected void btnVerwijderen_Click(object sender, EventArgs e)
        {
            //delete the current event ( isDeleted = 1 )

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //cancel the operation and return to main page
            Response.Redirect("~/default.aspx");
        }
    }
}



