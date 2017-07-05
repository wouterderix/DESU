using B2D3.Classes.CC;
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
            
            //Check if user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                //Als Identity zou werken in het project
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
                //Gebruiker heeft anoniem aangevinkt, dus _user wordt null
                else
                {
                    _user = null;
                }

                //De attribute onclick zorgt voor een popup in het scherm
                //Dit scherm laat weten dat de gebruiker niet is ingelogd en vraagt of hij/zij dit nog wilt doen
                //Omdat de gebruiker ingelogd is hoeft dit niet gevraagd te worden
                btSend.Attributes.Remove("onclick");
            }

            //If no user is authenticated
            else
            {
                //Als er geen gebruiker is ingelogd wordt _user null
                _user = null;

                //De attribute onclick zorgt voor een popup in het scherm
                //Dit scherm laat weten dat de gebruiker niet is ingelogd en vraagt of hij/zij dit nog wilt doen
                //Gebruiker vragen of hij of zij wilt inloggen
                btSend.Attributes.Add("onclick", "return ConfirmOnClick()");

                if (cbAnoniem.Checked)
                {
                    //Omdat de gebruiker anoniem wilt zijn wordt dit attribuut verwijderd
                    btSend.Attributes.Remove("onclick");
                }
            }
        }

        /// <summary>
        /// This method creates a new instance of CCContactopnemen and invokes the method GetSupervisors()
        /// The gridview gets the DataSource from the method GetSupervisors() as a datatable
        /// </summary>
        private void BindGrid()
        {
            gvGetSupervisors.DataSource = new CCContactOpnemen().GetSupervisors();
            gvGetSupervisors.DataBind();
        }

        /// <summary>
        /// This method creates a new instance of CCContactopnemen and invokes the method SaveMail(....)
        /// If successful; a popup shows that mail has been sent successfully
        /// If not successful; a popup shows that mail has not been sent successfully
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btSend_Click(object sender, EventArgs e)
        {
            CCContactOpnemen co = new CCContactOpnemen();

            if (co.SaveMail(tbName.Text, tbEmail.Text, tbSubject.Text, tbMessage.Text, _user))
            {
                StatusMessage.Text = "Mail is succesvol verzonden";

                tbName.Text = "";
                tbEmail.Text = "";
                tbSubject.Text = "";
                tbMessage.Text = "";
            }

            else
            {
                StatusMessage.Text = "Mail verzonden is mislukt";
            }
        }

        /// <summary>
        /// This is a Method that invokes when the checkbox "Anoniem" has been changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbAnoniem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAnoniem.Checked)
            {
                tbName.Text = "Anoniem";
                tbName.Enabled = false;
                tbName.Visible = false;
                lbName.Visible = false;

                tbEmail.Text = "anoniem.anoniem@a.com";
                tbEmail.Enabled = false;
                tbEmail.Visible = false;
                lbEmail.Visible = false;
            }

            else
            {
                tbName.Text = "";
                tbName.Enabled = true;
                tbName.Visible = true;
                lbName.Visible = true;

                tbEmail.Text = "";
                tbEmail.Enabled = true;
                tbEmail.Visible = true;
                lbEmail.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}