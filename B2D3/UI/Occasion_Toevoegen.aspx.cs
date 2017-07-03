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

        /// <summary>
        /// Handles the Click event of the btn_NewEvent and then gets the data to store a new Occasion from textboxes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btn_NewEvent_Click(object sender, EventArgs e)
        {
            var controller = new OccasionToevoegen();
            //If OccastionToevoegen.CC returns false, return Error_Label.Text. Else make a new Event and redirect to Overview
            if (!controller.newOccasion(TextBox1.Text, TextBox4.Text, Calendar1.SelectedDate, TextBox2.Text, TextBox3.Text))
            {
                Error_Label.Text = "Niet alle velden zijn ingevuld";
            }else
            {
                Response.Redirect("/UI/Occasion_Overzicht.aspx?NewOccasion=" + true);
            }
        }

        /// <summary>
        /// Handles the Click event of the btn_Cancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            //Cancel the operation and return to main page
            Response.Redirect("~/default.aspx");
        }
    }
}