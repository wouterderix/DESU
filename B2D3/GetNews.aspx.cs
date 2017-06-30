using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;

namespace B2D3
{
    public partial class GetNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetNewsCC gn = new GetNewsCC();

            GridView1.DataSource = gn.GetNews();
            GridView1.DataBind();
        }
    }
}