using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;
using B2D3.ControlClasses;
using B2D3.GlobalClasses;

namespace B2D3.UI
{
    [Author("Robin Jongen", "ProductAanpassen", Version = 0.1f)]
    public partial class viewProduct : System.Web.UI.Page
    {
        EditProductCC E = new EditProductCC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        
        private void BindGrid()
        {
            EditProductCC CC = new EditProductCC();
            GridView1.DataSource = CC.getList();
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string versie;
            GridView1.EditIndex = e.NewEditIndex;
            GridViewRow row = GridView1.Rows[GridView1.EditIndex];
            versie = row.Cells[10].Text + "&Version=" +  row.Cells[11].Text;
            Response.Redirect("/UI/EditProduct.aspx?ID=" + versie);
        }
    }
}