using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;

namespace B2D3.Classes.UI
{
    public partial class AuditLogUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void Generate_Click(object sender, EventArgs e)
        {
            if (Calendar.SelectedDate < DateTime.Now && Calendar.SelectedDate.ToString() != "1-1-0001 00:00:00")
            {
                HistoryCC CC = new HistoryCC();
                DateTime StartDate = Calendar.SelectedDate;
                GridView.DataSource = CC.GetData(StartDate);
                GridView.DataBind();
            }
            else
            {
                ErrorLabel.Text = "Selecteer een geldige datum";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}