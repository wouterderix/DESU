using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public partial class WorkItem
    {
        private int _id;
        private string _description;
        private string _result;
        private bool _isReviewed;
        private List<User> _users;

        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        [Required]
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
        public string Result
        {
            get
            {
                return _result;
            }

            set
            {
                _result = value;
            }
        }
        [Required]
        public bool IsReviewed
        {
            get
            {
                return _isReviewed;
            }

            set
            {
                _isReviewed = value;
            }
        }
        public List<User> Users
        {
            get
            {
                return _users;
            }

            set
            {
                _users = value;
            }
        }
    }
}