using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public class News : History
    {
        private string _title;
        private string _description;
        private DateTime _dueDate;

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
        public DateTime DueDate
        {
            get
            {
                return _dueDate;
            }

            set
            {
                _dueDate = value;
            }
        }

        public override bool IsEquivalent(IEquivalent other)
        {
            throw new NotImplementedException();
        }
    }
}