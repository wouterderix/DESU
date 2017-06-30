using B2D3.Classes.CC;
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
    [Author("Xavier van Egdom", "Nieuws goedkeuren")]
    public partial class ApproveNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetGridView();
        }


        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tbId.Text);
        }

        private void SetGridView()
        {
            gvNews.DataSource = new GetNewsCC().GetNews();
            gvNews.DataBind();
        }
    }
}