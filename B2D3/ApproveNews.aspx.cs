using B2D3.Classes.CC;
using B2D3.GlobalClasses;
using System;

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
            int historyId = int.Parse(tbIdH.Text);
            int versionId = int.Parse(tbIdV.Text);

            new ApprovedNewsCC().ApprovedNews(historyId, versionId);
        }

        private void SetGridView()
        {
            gvNews.DataSource = new GetNewsCC().GetNews();
            gvNews.DataBind();
        }
    }
}