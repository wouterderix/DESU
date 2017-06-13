using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public class User
    {
        private int _id;
        private string _userName;
        private byte[] _password;
        private AccountRole _accountRole;
        private List<History> _history;
        private bool _isActivel;

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
        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
            }
        }
        [Required]
        public byte[] Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }
        [Required]
        public AccountRole AccountRole
        {
            get
            {
                return _accountRole;
            }

            set
            {
                _accountRole = value;
            }
        }
        public List<History> History
        {
            get
            {
                return _history;
            }

            set
            {
                _history = value;
            }
        }
        [Required]
        public bool IsActivel
        {
            get
            {
                return _isActivel;
            }

            set
            {
                _isActivel = value;
            }
        }
    }
}