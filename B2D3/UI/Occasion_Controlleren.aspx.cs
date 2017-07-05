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
        protected void Page_Load(object sender, EventArgs e)
        {
            OccasionGet occasionGet = new OccasionGet();

            occasions = occasionGet.getNotApproved();
            
            UnapproveOccasions.DataSource = occasions;
            UnapproveOccasions.DataBind();
        }

        protected void BOccasionGoedkeuren_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach(GridViewRow row in UnapproveOccasions.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkChild");
                if (chk.Checked)
                {
                    occasions[i].IsApproved = true;
                }
                i++;
            }
        }

        protected void Bterug_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}