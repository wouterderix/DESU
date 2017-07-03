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

        List<Occasion> occasions2 = new List<Occasion>();
        protected void Page_Load(object sender, EventArgs e)
        {

            OccasionGet occasionGet = new OccasionGet();
            
            occasions = occasionGet.getNotApproved();

            if (!IsPostBack)
            {
                UnapproveOccasions.DataSource = occasions;
                UnapproveOccasions.DataBind();
            }
        }

        protected void BOccasionGoedkeuren_Click1(object sender, EventArgs e)
        {
            //runs when button is pressed

            //creates new object of OccasionBewerken
            OccasionBewerken bewerken = new OccasionBewerken();

            //checks what checkbox is pressed and approves each
            int i = 0;
            foreach (GridViewRow row in UnapproveOccasions.Rows)
            {
                //CheckBox chk = row.Cells[0].Controls[0] as CheckBox;
                //if (chk != null && chk.Checked)
                //{
                //    bewerken.occasionGoedkeuren(occasions[i]);
                //}

                CheckBox chk = (CheckBox)row.FindControl("SelectCheckbox");
                Debug.WriteLine(occasions.Count());
                Debug.WriteLine(i);
                if (chk.Checked)
                {
                    bewerken.occasionGoedkeuren(occasions[i]);

                }
                i++;
            }
        }
    }
}