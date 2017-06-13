using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public abstract class History : IEquivalent
    {
        private int _id;
        private int _version;
        private User _author;
        private DateTime _logDate;
        private bool _isDeleted;

        [Key, Column(Order =0)]
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
        [Key, Column(Order =1)]
        public int Version
        {
            get
            {
                return _version;
            }

            set
            {
                _version = value;
            }
        }
        [Required]
        public User Author
        {
            get
            {
                return _author;
            }

            set
            {
                _author = value;
            }
        }
        [Required]
        public DateTime LogDate
        {
            get
            {
                return _logDate;
            }

            private set
            {
                _logDate = value;
            }
        }
        [Required]
        public bool IsDeleted
        {
            get
            {
                return _isDeleted;
            }

            set
            {
                _isDeleted = value;
            }
        }

        public History(History oldVersion, User author, bool isDeleted)
        {
            ID = oldVersion.ID;
            Version = oldVersion.Version + 1;
            Author = author;
            LogDate = DateTime.UtcNow;
            IsDeleted = isDeleted;
        }
        public History(User author, bool isDeleted)
        {
            Author = author;
            IsDeleted = isDeleted;
            LogDate = DateTime.UtcNow;
            Version = 1;
        }

        public abstract bool IsEquivalent(IEquivalent other);
    }
}