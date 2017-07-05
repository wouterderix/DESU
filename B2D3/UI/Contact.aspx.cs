using B2D3.Classes.CC;
using B2D3.GlobalClasses;
using System;

namespace B2D3.Classes.UI
{
    [Author("Job Hollands", "Contact Opnemen")]
    public partial class Contact : System.Web.UI.Page
    {
        private static User _user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

            if (User.Identity.IsAuthenticated)
            {
                if (!cbAnoniem.Checked)
                {
                    //Alle gegevens van user verkrijgen

                    //VIA IDENTITY
                    //_userID = User.Identity.GetUserId();

                    //VIA IDENTITY
                    //tbName.Text = User.Identity.GetUserName();

                    //Via 5 lagen-model
                    //tbEmail.Text = new CCContactOpnemen().GetEmailAdress(_userID);
                }
                else
                {
                    _user = null;
                }
                btSend.Attributes.Remove("onclick");
            }

            else
            {
                _user = null;
                //Gebruiker vragen of hij of zij wilt inloggen
                btSend.Attributes.Add("onclick", "return ConfirmOnClick()");

                if (cbAnoniem.Checked)
                {
                    btSend.Attributes.Remove("onclick");
                }
            }
        }

        private void BindGrid()
        {
            gvGetSupervisors.DataSource = new CCContactOpnemen().GetSupervisors();
            gvGetSupervisors.DataBind();
        }

        protected void btSend_Click(object sender, EventArgs e)
        {
            CCContactOpnemen co = new CCContactOpnemen();

            if (co.SaveMail(tbName.Text, tbEmail.Text, tbSubject.Text, tbMessage.Text, _user))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Mail is succesvol verzonden');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Mail verzonden is mislukt');", true);
            }
        }

        protected void cbAnoniem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAnoniem.Checked)
            {
                tbName.Text = "Anoniem";
                tbEmail.Text = "anoniem.anoniem@a.com";
            }

            else
            {
                tbName.Text = "";
                tbEmail.Text = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}