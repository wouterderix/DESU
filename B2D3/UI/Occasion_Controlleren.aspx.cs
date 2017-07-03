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
        //Kay Karssing

        //makes a list with type Occasion to store all the Occasions gotten from the database
        List<Occasion> occasions = new List<Occasion>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //runs when page loads

            //makes a new instance of occasionGet wich makes it possible to communicate with the control class
            OccasionGet occasionGet = new OccasionGet();
            
            //fetches all unapproved occasions from the database
            occasions = occasionGet.getNotApproved();

            //only runs if this is not a postback
            if (!IsPostBack)
            {
                //sets the scource of the gridview
                UnapproveOccasions.DataSource = occasions;
                //binds the scource so it will display in the gridview
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
                CheckBox chk = (CheckBox)row.FindControl("SelectCheckbox");
                if (chk.Checked)
                {
                    //if a checkbox is checked the occasion in that row will be approved
                    bewerken.occasionGoedkeuren(occasions[i]);
                }
                i++;
            }
        }
    }
}