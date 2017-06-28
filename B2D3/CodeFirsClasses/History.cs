using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public abstract partial class History : IEquivalent
    {
        private int _id;
        private int _version;
        private User _author;
        private DateTime _logDate;
        private bool _isDeleted;

        [Key, Column(Order =0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryID
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

        private History(int id, int version, User author, bool isDeleted)
        {
            HistoryID = id;
            Version = version;
            Author = author;
            IsDeleted = isDeleted;
            LogDate = DateTime.UtcNow;
        }
        public History(History oldVersion, User author, bool isDeleted)
            : this(oldVersion.HistoryID, oldVersion.Version + 1, author, isDeleted) { }
        public History(User author, bool isDeleted)
            : this(0, 1, author, isDeleted) { }
        public History(User author)
            : this(author, false) { }
        public History() { }

        public abstract bool IsEquivalent(IEquivalent other);
    }
}