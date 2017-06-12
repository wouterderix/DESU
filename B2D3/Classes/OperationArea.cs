using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public class OperationArea
    {
        private int _id;
        private string _name;
        private List<Category> _categories;

        public int Id
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
        public List<Category> Categories
        {
            get
            {
                return _categories;
            }

            set
            {
                _categories = value;
            }
        }
    }
}