using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.ControlClasses;

namespace B2D3
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            GridView1.DataSource = SearchProduct.GetAllProducts();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = SearchProduct.SearchByName("rolstoel");
        }
    }
}