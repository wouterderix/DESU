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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //get event information when page gets loaded


            var o = new OccasionGet();
            /*int history = Int32.Parse(o.Doorgeefinfo[0]);
            int version = Int32.Parse(o.Doorgeefinfo[1]);
            string title = o.Doorgeefinfo[2];*/
           
            int history = Convert.ToInt32(Request.QueryString["HistoryID"]);
            //return to default if no history id is given
            if (history == 0)
            { Response.Redirect("/default.aspx"); }

            Occasion occasion = o.getOccasion(history);
            
            EventTitel.Text = occasion.Title;
            TBTitle.Text = occasion.Title;
            TBBeschrijving.Text = occasion.Description;
            System.DateTime datetime = occasion.Date;
            TBDatum.Text = datetime.ToString("yyyy-MM-dd");
            TBPlaats.Text = occasion.Location;
            TBUrl.Text = occasion.MoreInformationURL;
        }

        protected void btnBewerk_Click(object sender, EventArgs e)
        {
            //edit the currently loaded event
            var oGet = new OccasionGet();
            /*int history = Int32.Parse(oGet.Doorgeefinfo[0]);
            int version = Int32.Parse(oGet.Doorgeefinfo[1]);
            string title = oGet.Doorgeefinfo[2];*/
            int history = 3;
            int version = 1;
            string title = TBTitle.Text;
            string description = TBBeschrijving.Text;
            System.DateTime date = Convert.ToDateTime(TBDatum.Text);
            string location = TBPlaats.Text;
            string moreInformationURL = TBUrl.Text;
            Debug.WriteLine(history + version + title + description + date + location + moreInformationURL);

            var o = new OccasionBewerken();
            if (o.occasionBewerken(history, version, title, description, date, location, moreInformationURL)){
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



