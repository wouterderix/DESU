using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace B2D3.Classes
{
    [Author("Job Hollands", "Contact Opnemen")]
    public partial class Contact
    {
        private static string _contactEmailadress = "zuydergotherapie@gmail.com";
        private static DataTable dt;

        public bool saveMail(string name, string email, string subject, string message, User user)
        {
            try
            {
                using (Casusblok5Model context = new Casusblok5Model())
                {
                    Contact contact = new Contact();

                    contact.SubmittedUser = user;
                    contact.Name = name;
                    contact.EmailAddress = email;
                    contact.Subject = subject;
                    contact.Message = message;

                    context.Contact.Add(contact);
                    context.SaveChanges();
                }

                // mail versturen
                // zuydergotherapie is het VAN emailadres
                sendMail(_contactEmailadress, email, name, subject, message);

                if (name != "Anoniem")
                {
                    // bevestigingsmail naar de verzender sturen
                    sendMail(email, email, name, subject, message);
                }

                return true;
            }

            catch
            {
              return false;
            }
        }

        public void sendMail(string toEmailadress, string fromEmailadress, string name, string subject, string message)
        {
            using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["SMTPuser"], toEmailadress))
            {
                if (toEmailadress == _contactEmailadress)
                {
                    //onderwerp van de mail
                    mm.Subject = subject;
                    //bericht van de mail
                    mm.Body = "Naam: " + name + "\n" +
                        "E-mailadres: " + fromEmailadress + "\n" + "\n" +
                        message;
                }

                else
                {
                    mm.Subject = "No-reply Zuyd Ergotherapie";
                    //bericht van de mail
                    mm.Body = "Uw zojuist verzonden bericht." + "\n" + "\n" + message;
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"]); ;
                NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["SMTPuser"], ConfigurationManager.AppSettings["SMTPpassword"]);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); ;
                smtp.Send(mm);
            }
        }

        public DataTable GetSupervisors()
        {
            dt = new DataTable();
            try
            {
                string connString = @"Server=u17697p13129.web0113.zxcs.nl; Database=u17697p13129_TestRobin; Uid=u17697p13129_B2A5user; Pwd=CasusB2A5*;";
                string query = "select Users.UserName Gebruikersnaam, AccountRoles.Name Accountrol from Users join AccountRoles ON Users.AccountRole_ID = AccountRoles.ID where AccountRoles.ID = 2 ";

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                // this will query your database and return the result to your datatable

                da.Fill(dt);

                conn.Close();

                da.Dispose();

                return dt;
            }
            catch
            {
                return dt;
            }
        }
    }
}