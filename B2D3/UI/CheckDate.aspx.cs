using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;
using System.Data;
using B2D3.GlobalClasses;

namespace B2D3.Classes.UI
{
    [Author("Thom Kemp", "Houdbaarheidsdatum Controleren", Version = 1)]
    public partial class CheckDate : System.Web.UI.Page
    {
        /// <summary>
        /// When page loads this function will be called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        /// <summary>
        /// Prevents refresh of data when page is reloaded
        /// </summary>
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

        /// <summary>
        /// This action is called when user pressed on btnModify
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModify_Click(object sender, EventArgs e)
        {
            int productID;
            int versionID;
            int dimensionID;
            DateTime newDate;
            if (int.TryParse(modifyID.Text, out productID) && int.TryParse(verID.Text, out versionID) && int.TryParse(dimID.Text, out dimensionID))
            {
                CheckDateCC CC = new CheckDateCC();
                newDate = DatePicker.SelectedDate;
                ErrorMessage2.Text = CC.ModifyProduct(productID, versionID, dimensionID, newDate);
            }
            else
            {
                ErrorMessage2.Text = "Vul een geldig ID in.";
            }
        }

        /// <summary>
        /// This action is called when user pressed on btnDelete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int productID;
            int versionID;
            int dimensionID;
            if (int.TryParse(modifyID.Text, out productID) && int.TryParse(verID.Text, out versionID) && int.TryParse(dimID.Text, out dimensionID))
            {
                CheckDateCC CC = new CheckDateCC();
                ErrorMessage2.Text = CC.DeleteProduct(productID, versionID, dimensionID);
            } else
            {
                ErrorMessage2.Text = "Vul een geldig ID in.";
            }          
        }

        /// <summary>
        /// This disables/enables the visability of the form inputs and labels
        /// </summary>
        /// <param name="visible">Enable (view) inputs and labels = true, disable (hide) inputs and labels = false</param>
        private void formVisible(bool visible)
        {
            info1.Visible = info2.Visible = modifyID.Visible = modLab.Visible = verID.Visible = verLab.Visible = dimID.Visible = dimLab.Visible = dateLab.Visible = DatePicker.Visible = btnDelete.Visible = btnModify.Visible = visible;
        }
    }
}