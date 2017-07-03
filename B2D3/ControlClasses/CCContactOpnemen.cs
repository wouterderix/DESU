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

        public DataTable GetSupervisors()
        {
            return new Contact().GetSupervisors();   
        }
    }
}