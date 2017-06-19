using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    [Table("Products")]
    public class Product : History
    {
        #region fields
        private string _name;
        private string _information;
        private DateTime _expirationDate;
        private int _timesViewed;
        private bool _isCompensated;
        private decimal _price;
        private bool _isApproved;
        private Supplier _supplier;
        private List<ProductReview> _reviews;
        private Category _productCategory;
        private List<OperationArea> _productOperationAreas;
        private int _weight;
        private string _pictureURL;
        private string _videoURL;
        private string _userGuide;
        private Dimension _dimension;
        private List<Picture> _picture;
        private List<Demands> _demands;
        private List<Specification> __specification;

        #endregion


        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        public List<OperationArea> ProductOperationAreas
        {
            get
            {
                return _productOperationAreas;
            }

            set
            {
                _productOperationAreas = value;
            }
        }
        public int Weight
        {
            get
            {
                return _weight;
            }

            set
            {
                _weight = value;
            }
        }
        public string PictureURL
        {
            get
            {
                return _pictureURL;
            }

            set
            {
                _pictureURL = value;
            }
        }
        public string VideoURL
        {
            get
            {
                return _videoURL;
            }

            set
            {
                _videoURL = value;
            }
        }
        public string UserGuide
        {
            get
            {
                return _userGuide;
            }

            set
            {
                _userGuide = value;
            }
        }
        public Dimension Dimension
        {
            get
            {
                return _dimension;
            }

            set
            {
                _dimension = value;
            }
        }
        public List<Picture> Picture
        {
            get
            {
                return _picture;
            }

            set
            {
                _picture = value;
            }
        }
        public List<Demands> Demands
        {
            get
            {
                return _demands;
            }

            set
            {
                _demands = value;
            }
        }
        public List<Specification> Specification
        {
            get
            {
                return __specification;
            }

            set
            {
                __specification = value;
            }
        }


        public Product(Product oldVersion, User author, bool isDeleted)
            : base(oldVersion, author, isDeleted)
        {
        }
        public Product(User author, bool isDeleted)
            : base(author, isDeleted)
        {
        }
        public Product() { }




        public override bool IsEquivalent(IEquivalent other)
        {
            throw new NotImplementedException();
        }
    }
}