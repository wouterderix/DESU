using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;

namespace B2D3.Classes.UI
{
    public partial class ReviewProduct : System.Web.UI.Page
    {
        private int productId = 1;
        private int productVersion = 1;
        private int? UserId = 2;
        private DateTime reviewDate;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Hier functie van Xavier aanroepen (getUserId). Als deze null is, dan is de gebruiker niet ingelogd 
            // en zal dit eerst moeten gebeuren alvorens de gebruiker een review kan plaatsen. Verder moet hier
            // het productID en de versionID worden opgehaald.

            //if (UserID == null)
            //{
            //    // Popup scherm voor in te loggen 
            //}
            //else
            //{
            //    // waarde van getUserid toekennen aan UserID
            //}

            reviewDate = DateTime.UtcNow;
            B2D3.Classes.CC.ReviewProduct rvCC = new B2D3.Classes.CC.ReviewProduct();
            // Als review succesvol is toegevoegd verschijnt melding en wordt productpagina met review
            // onderaan geladen. Als er iets fout gaat, verschijnt er een melding en kan het review
            // worden aangepast/anders ingevuld.
            if (rvCC.PlaceReview(Review.Text, Rating.SelectedValue, reviewDate, Anoniem.Checked,
                productId, productVersion, UserId))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Review succesvol toegevoegd');", true);
                // Herlaad productpagina met geplaatst review
                // Server.Transfer("Hier de link naar de betreffende pagina invullen",true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Er ging iets fout, probeer opnieuw');", true);
                // Teruggaan naar review invullen
            }
        }
    }
}