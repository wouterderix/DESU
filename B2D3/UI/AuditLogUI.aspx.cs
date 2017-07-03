using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B2D3.Classes.CC;
using B2D3.GlobalClasses;

namespace B2D3.Classes.UI
{
    /// <summary>
    /// Pagina voor het inzien van audit log
    /// </summary>
    [Author("Yannic van de kuit & Ramon Cremers", "Audit Log", Version = 1.0f)]
    public partial class AuditLogUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void Generate_Click(object sender, EventArgs e)
        {
            //controle of er een geldige datum is ingevoerd
            if (Calendar.SelectedDate < DateTime.Now && Calendar.SelectedDate.ToString() != "1-1-0001 00:00:00")
            {
                ErrorLabel.Visible = false;
                HistoryCC CC = new HistoryCC();
                DateTime StartDate = Calendar.SelectedDate;
                GridView.DataSource = CC.GetData(StartDate);
                GridView.DataBind();
            }
            else
            {
                //melding als er geen geldige datum is ingevuld
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "Selecteer een geldige datum";
            }
        }
    }
}