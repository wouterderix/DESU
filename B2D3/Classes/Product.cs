using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public class Product : History
    {
        private string _name;
        private int _quantity;
        private string _information;
        private DateTime _expirationDate;
        private int _timesViewed;
        private bool _isCompensated;
        private decimal _price;
        private bool _isApproved;
        private Supplier _supplier;
        private List<ProductReview> _reviews;
        private Category _productCategory;

        public Product(Product oldVersion, User author, bool isDeleted) 
            : base(oldVersion, author, isDeleted)
        {
        }

        public Product(User author, bool isDeleted) 
            : base(author, isDeleted)
        {
        }

        [Index(IsUnique = true), StringLength(100)]
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
        public int Quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                _quantity = value;
            }
        }
        public string Information
        {
            get
            {
                return _information;
            }

            set
            {
                _information = value;
            }
        }
        public DateTime ExpirationDate
        {
            get
            {
                return _expirationDate;
            }

            set
            {
                _expirationDate = value;
            }
        }
        public int TimesViewed
        {
            get
            {
                return _timesViewed;
            }

            set
            {
                _timesViewed = value;
            }
        }
        public bool IsCompensated
        {
            get
            {
                return _isCompensated;
            }

            set
            {
                _isCompensated = value;
            }
        }
        public decimal Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }
        public bool IsApproved
        {
            get
            {
                return _isApproved;
            }

            set
            {
                _isApproved = value;
            }
        }
        public Supplier Supplier
        {
            get
            {
                return _supplier;
            }

            set
            {
                _supplier = value;
            }
        }
        public List<ProductReview> Reviews
        {
            get
            {
                return _reviews;
            }

            set
            {
                _reviews = value;
            }
        }
        public Category ProductCategory
        {
            get
            {
                return _productCategory;
            }

            set
            {
                _productCategory = value;
            }
        }

        public override bool IsEquivalent(IEquivalent other)
        {
            throw new NotImplementedException();
        }
    }
}