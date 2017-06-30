using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    [Table("Occasions")]
    public partial class Occasion : History
    {
        private string _title;
        private string _description;
        private DateTime _date;
        private string _location;
        private string moreInformationURL;

        public Occasion(Occasion oldVersion, User author, bool isDeleted) 
            : base(oldVersion, author, isDeleted)
        {
        }

        public Occasion(User author, bool isDeleted) 
            : base(author, isDeleted)
        {
        }

        [Required]
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
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
        [Required]
        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }
        [Required]
        public string Location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = value;
            }
        }
        [Required]
        public string MoreInformationURL
        {
            get
            {
                return moreInformationURL;
            }

            set
            {
                moreInformationURL = value;
            }
        }

        public override bool IsEquivalent(IEquivalent other)
        {
            throw new NotImplementedException();
        }
    }
}