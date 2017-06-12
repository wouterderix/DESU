using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public class Occasion : History
    {
        private string _title;
        private string _description;
        private DateTime _date;
        private string _location;
        private string moreInformationURL;
        private bool _isApproved;

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

        public override bool IsEquivalent(IEquivalent other)
        {
            throw new NotImplementedException();
        }
    }
}