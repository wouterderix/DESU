using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;

namespace B2D3.UI
{
    public partial class WorkItemUI : System.Web.UI.Page
    {
        WorkItemCC wi = new WorkItemCC();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void Button_Click(object sender, EventArgs e)
        //{
        //    GridView1.DataSource = wi.FetchTable();
        //    GridView1.DataBind();
        //}

    }
}