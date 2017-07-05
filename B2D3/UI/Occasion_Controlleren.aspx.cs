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
    public partial class OccasionControlleren : System.Web.UI.Page
    {
        List<Occasion> occasions = new List<Occasion>();

        [Author("Kay Karssing", "occasions ophalen", Version = 1.0f)]
        protected void Page_Load(object sender, EventArgs e)
        {
            OccasionGet occasionGet = new OccasionGet();

            occasions = occasionGet.getNotApproved();
            
            UnapproveOccasions.DataSource = occasions;
            UnapproveOccasions.DataBind();
        }

        [Author("Kay Karssing", "occasions goedkeuren", Version = 1.0f)]
        protected void BOccasionGoedkeuren_Click(object sender, EventArgs e)
        {
            OccasionBewerken goedkeuren = new OccasionBewerken();

            int i = 0;
            foreach(GridViewRow row in UnapproveOccasions.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkChild");
                if (chk.Checked)
                {
                    goedkeuren.occasionGoedkeuren(occasions[i]);
                }
                i++;
            }
            Response.Redirect("~/UI/Occasion_Controlleren.aspx");
        }

        [Author("Kay Karssing", "terug knop", Version = 1.0f)]
        protected void Bterug_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}