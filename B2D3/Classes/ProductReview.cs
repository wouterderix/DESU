using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public class ProductReview
    {
        private int _id;
        private string _reviewText;
        private DateTime _reviewDate;
        private User _author;
        private bool _isAnonymous;

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
        public string ReviewText
        {
            get
            {
                return _reviewText;
            }

            set
            {
                _reviewText = value;
            }
        }
        public DateTime ReviewDate
        {
            get
            {
                return _reviewDate;
            }

            set
            {
                _reviewDate = value;
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
        public bool IsAnonymous
        {
            get
            {
                return _isAnonymous;
            }

            set
            {
                _isAnonymous = value;
            }
        }
    }
}