using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;

namespace B2D3.Classes.UI
{
    /// <summary>
    /// behoort tot UC Product verwijderen
    /// gemaakt door Rowan Koenen
    /// </summary>

    public partial class DeleteProductTest : System.Web.UI.Page
    {
        DeleteProductCC DeleteProductControlClass = new DeleteProductCC();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dltBtn_Click(object sender, EventArgs e)
        {
            if (DeleteProductControlClass.PassAlongProducts(TextBoxDelete.Text))
            {
                //noError fornowdonothing
            }

            else
            {
                //yesError
                ButtonError.Enabled = true; LableError.Enabled = true;
                ButtonError.Visible = true; LableError.Visible = true;
            }
        }

        protected void errorBtn_Click(object sender, EventArgs e)
        {
            TextBoxDelete.Text = "";
            ButtonError.Enabled = false; LableError.Enabled = false;
            ButtonError.Visible = false; LableError.Visible = false;
        }
    }
}