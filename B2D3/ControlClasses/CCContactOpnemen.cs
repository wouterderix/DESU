using B2D3.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    [Author("Job Hollands", "Contact Opnemen")]
    public class CCContactOpnemen
    {
        /// <summary>
        /// This method passes data to save and send the mail
        /// This method returns a boolean if mail has been saved and send correctly or not
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SaveMail(string name, string email, string subject, string message, User user)
        {
            Contact contact = new Contact();

            if (contact.saveMail(name, email, subject, message, user))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method returns the supervisors in a datatable
        /// </summary>
        /// <returns></returns>
        public DataTable GetSupervisors()
        {
            return new Contact().GetSupervisors();   
        }


        /// <summary>
        /// This method returns the user's emailadress
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        //public string GetEmailAdress(string userID)
        //{
        //    return new IdentityExtensions().GetEmailAdress(userID);
        //}
    }
}