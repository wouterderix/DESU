using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public partial class ProductReview
    {
        private int _id;
        private string _reviewText;
        private int _starRating;
        private DateTime _reviewDate;
        private User _author;
        private bool _isAnonymous;

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
        [Required]
        public int StarRating
        {
            get
            {
                return _starRating;
            }

            set
            {
                _starRating = value;
            }
        }  
        [Required]
        public DateTime ReviewDate
        {
            get
            {
                return _reviewDate;
            }

            private set
            {
                _reviewDate = value;
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