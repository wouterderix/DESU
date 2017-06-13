using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public class AccountRole
    {
        private int _id;
        private string _name;
        private string _description;
        private byte _accountLevel;

        [Key]
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
        [Index(IsUnique = true), StringLength(100), Required]
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
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }
        public byte AccountLevel
        {
            get
            {
                return _accountLevel;
            }

            set
            {
                _accountLevel = value;
            }
        }
    }
}