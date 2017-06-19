using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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