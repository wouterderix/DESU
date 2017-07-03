using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;

namespace B2D3.Classes.UI
{
    public partial class CheckDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            CheckDateCC CC = new CheckDateCC();
            if (CC.CheckDate().Rows.Count == 0)
            {
                ErrorMessage.Text = "Er zijn geen producten waarvan de houdbaarheidsdatum gecontroleerd moet worden.";
                formVisible(false);
            } else
            {
                DataTable.DataSource = CC.CheckDate();
                DataTable.DataBind();
                formVisible(true);
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            int productID;
            DateTime newDate;
            if (int.TryParse(modifyID.Text, out productID))
            {
                CheckDateCC CC = new CheckDateCC();
                newDate = DatePicker.SelectedDate;
                ErrorMessage2.Text = CC.ModifyProduct(productID, newDate);
            }
            else
            {
                ErrorMessage2.Text = "Vul een geldig ID in.";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int productID;
            if (int.TryParse(modifyID.Text, out productID))
            {
                CheckDateCC CC = new CheckDateCC();
                ErrorMessage2.Text = CC.DeleteProduct(productID);
            } else
            {
                ErrorMessage2.Text = "Vul een geldig ID in.";
            }          
        }

        private void formVisible(bool visible)
        {
            modifyID.Visible = btnDelete.Visible = btnModify.Visible = visible;
        }
    }
}