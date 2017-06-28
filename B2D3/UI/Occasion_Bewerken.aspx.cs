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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //get event information when page gets loaded


            var o = new OccasionGet();
            Occasion occasion = o.getOccasion(/*history, version,*/ title);


            TBTitle.Text = occasion.Title;
            TBBeschrijving.Text = occasion.Description;
            System.DateTime datetime = occasion.Date;
            TBDatum.Text = datetime.ToString();
            TBPlaats.Text = occasion.Location;
            TBUrl.Text = occasion.MoreInformationURL;
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



