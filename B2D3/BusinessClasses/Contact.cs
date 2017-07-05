using B2D3.GlobalClasses;
using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Mail;

namespace B2D3.Classes
{
    [Author("Job Hollands", "Contact Opnemen")]
    public partial class Contact
    {
        private static string _contactEmailadress = "zuydergotherapie@gmail.com";
        private static DataTable dt;

        /// <summary>
        /// This method saves the contact information in the database.
        /// After it is successfully saved the method sendMail will invoke
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method sends an email
        /// </summary>
        /// <param name="toEmailadress"></param>
        /// <param name="fromEmailadress"></param>
        /// <param name="name"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
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

        /// <summary>
        /// This method returns all supervisors with their Username and accountrole name
        /// In the future this method will be updated; than it needs to return the first name, last name and phonenumber of all supervisors
        /// </summary>
        /// <returns></returns>
        public DataTable GetSupervisors()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["Casusblok5Model"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("select Users.UserName Gebruikersnaam, AccountRoles.Name Accountrol from Users join AccountRoles ON Users.AccountRole_ID = AccountRoles.ID where AccountRoles.ID = 2"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            }
            catch
            {
                return dt;
            }


        }
    }
}