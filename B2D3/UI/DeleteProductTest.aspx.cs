using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;
using B2D3.GlobalClasses;

namespace B2D3.Classes.UI
{
    [Author("Rowan Koenen", "Product Verwijderen", Version = 1)]
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
                //noError
                ButtonConfirm.Enabled = true; LableConfirm.Enabled = true;
                ButtonConfirm.Visible = true; LableConfirm.Visible = true;
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

        protected void confirmBtn_click(object sender, EventArgs e)
        {
            TextBoxDelete.Text = "";
            ButtonConfirm.Enabled = false; LableConfirm.Enabled = false;
            ButtonConfirm.Visible = false; LableConfirm.Visible = false;
        }
    }
}