using B2D3.ControlClasses;
using B2D3.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B2D3
{
    public partial class _ApproveProductCC : System.Web.UI.Page
    {
        ApproveProduct ApproveProducts = new ApproveProduct();

        protected void Page_Load(object sender, EventArgs e)
        {
            SetGridView();
            
        }
        private void SetGridView()
        {              
            gvProduct.DataSource = new ApproveProduct().getDataTable();
            gvProduct.DataBind();
        }

        protected void SendApproveProduct_Click(object sender, EventArgs e)
        {
            if ( ApproveProducts.ApprovedProduct(Convert.ToInt32(HistoryID.Text), Convert.ToInt32(Version.Text)))
            {
                ConfirmLabel.Text = "Product is goedgekeurd. . .";

                ConfirmLabel.Visible = true;
                ConfirmLabel.Enabled = true;
                ConfirmButton.Visible = true;
                ConfirmButton.Enabled = true;
            }

            else
            {
                ConfirmLabel.Text = "Product bestaat niet, of actie is mislukt. . .";

                ConfirmLabel.Visible = true;
                ConfirmLabel.Enabled = true;
                ConfirmButton.Visible = true;
                ConfirmButton.Enabled = true;
            }
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            HistoryID.Text = "";
            Version.Text = "";

            ConfirmLabel.Visible = false;
            ConfirmLabel.Enabled = false;
            ConfirmButton.Visible = false;
            ConfirmButton.Enabled = false;

            Response.Redirect(Request.RawUrl);
        }
    }

    
}