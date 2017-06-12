using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public class Contact
    {
        private int _id;
        private string _name;
        private string _emailAddress;
        private string _subject;
        private string _message;
        private User _submittedUser;

        public int ID
        {
            get
            {
                return _id;
            }

            private set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }

            set
            {
                _emailAddress = value;
            }
        }
        public string Subject
        {
            get
            {
                return _subject;
            }

            set
            {
                _subject = value;
            }
        }
        public string Message
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
            }
        }
        public User SubmittedUser
        {
            get
            {
                return _submittedUser;
            }

            set
            {
                _submittedUser = value;
            }
        }
    }
}