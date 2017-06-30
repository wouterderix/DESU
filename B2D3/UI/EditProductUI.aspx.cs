using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;
using B2D3.ControlClasses;

namespace B2D3.UI
{
    public partial class EditProductUI : System.Web.UI.Page
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
    }
}