using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;
using System.Diagnostics;

namespace B2D3.Classes.UI
{

    public partial class _Occasion_Bewerken : Page
    {
        /// <summary>
        /// main page event bewerken
        /// user gets page with current information of event, can edit and commit to database
        /// also used to EventToevoegen
        /// </summary>
        Occasion oldOccasion;
        protected void Page_Load(object sender, EventArgs e)
        {
            //get event information when page gets loaded
            var o = new OccasionGet();
            //Check if there is a valid HistoryID
            if(Request.QueryString["HistoryID"] != "" && Request.QueryString["HistoryID"] != null)
            {
                //Get Occasion by HistoryID from link
                int history = Convert.ToInt32(Request.QueryString["HistoryID"]);
                oldOccasion = o.getOccasion(history);


                EventTitel.Text = oldOccasion.Title;
                //Check if the load request is not a Postback(button click event)
                if (!IsPostBack)
                {
                    //Fill the textboxes
                    TBTitle.Text = oldOccasion.Title;
                    TBBeschrijving.Text = oldOccasion.Description;
                    System.DateTime datetime = oldOccasion.Date;
                    TBDatum.Text = datetime.ToString("yyyy-MM-dd");
                    TBPlaats.Text = oldOccasion.Location;
                    TBUrl.Text = oldOccasion.MoreInformationURL;
                }
            }
            else
            {
                //return to default if no history id is given
                Response.Redirect("/default.aspx");
            }    

        }

        protected void btnBewerk_Click(object sender, EventArgs e)
        {
            //Extract the data from the TextBoxes
            string title = TBTitle.Text;
            string description = TBBeschrijving.Text;
            System.DateTime date = Convert.ToDateTime(TBDatum.Text);
            string location = TBPlaats.Text;
            string moreInformationURL = TBUrl.Text;

            var o = new OccasionBewerken();
            //Edit occasion and pass along the oldOccasion
            if (o.occasionBewerken(oldOccasion, title, description, date, location, moreInformationURL)){
                Debug.WriteLine("occasion bewerkt");
                Response.Redirect("/default.aspx");
            } else
            {
                EventTitel.ForeColor = System.Drawing.Color.Red;
                EventTitel.Text = "ERROR: please check entered information.";
            }

        }

        protected void btnVerwijderen_Click(object sender, EventArgs e)
        {
            //delete the current event ( isDeleted = 1 )
            int history = Convert.ToInt32(Request.QueryString["HistoryID"]);
            var o = new OccasionsVerwijder();
            o.verwijderOccasion(history);
            Response.Redirect("~/default.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //cancel the operation and return to main page
            Response.Redirect("~/default.aspx");
        }
    }
}



