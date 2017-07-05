using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;
using System.Data;

namespace B2D3
{
    public partial class GetNews : System.Web.UI.Page
    {
        private static string _userName = "Bobbie";
        private static int _id = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            lDocentNaam.Text = _userName;
            SetGridView();
        }

        private void SetGridView()
        {
            GetNewsCC gn = new GetNewsCC();

            GridView1.DataSource = gn.GetNews();
            GridView1.DataBind();
        }

        protected void GridViewSelectEventHandler(object sender, GridViewSelectEventArgs e)
        {
            GetNewsCC gn = new GetNewsCC();

            ///gn.GetNewsByID();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}