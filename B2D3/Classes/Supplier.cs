using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public class Supplier
    {
        private int _id;
        private string _name;
        private string _address;
        private string _zipCode;
        private string _phone;
        private string _email;

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
        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }
        public string ZipCode
        {
            get
            {
                return _zipCode;
            }

            set
            {
                _zipCode = value;
            }
        }
        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                _phone = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }
    }
}