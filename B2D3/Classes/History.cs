using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public abstract class History : IEquivalent
    {
        private int _id;
        private uint _version;
        private User _author;
        private DateTime _logDate;
        private bool _isDeleted;

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
        public uint Version
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
        public DateTime LogDate
        {
            get
            {
                return _logDate;
            }

            set
            {
                _logDate = value;
            }
        }
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

        public abstract bool IsEquivalent(IEquivalent other);
    }
}