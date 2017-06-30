using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;

namespace B2D3.UI
{
    public partial class Occasion_Toevoegen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_NewEvent_Click(object sender, EventArgs e)
        {
            
            var controller = new OccasionToevoegen();     
            if(!controller.newOccasion(TextBox1.Text, TextBox4.Text, Calendar1.SelectedDate, TextBox3.Text, TextBox2.Text))
            {
                Error_Label.Text = "Niet alle velden zijn ingevuld";
            }else
            {
                Response.Redirect("/UI/Occasion_Overzicht.aspx?NewOccasion=" + true);
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            //cancel the operation and return to main page
            Response.Redirect("~/default.aspx");
        }
    }
}