using B2D3.Classes.CC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B2D3
{
    public partial class UpdateNews : System.Web.UI.Page
    {
        private int authorId;

        protected void Page_Load(object sender, EventArgs e)
        {
            authorId = 5;

            gvNews.DataSource = new GetNewsCC().GetNews();
            gvNews.DataBind();
        }

        private void UpdateNewsMethode()
        {
            int historyId = int.Parse(tbHistoryId.Text);
            int versionId = int.Parse(tbVersionId.Text);
            string title = tbTitle.Text;
            string description = tbDescription.Text;
            bool approved = bool.Parse(rblApproved.SelectedItem.Text);

            new UpdateNewsCC().UpdateNews(historyId, versionId, title, description, approved, authorId);
        }


    }
}