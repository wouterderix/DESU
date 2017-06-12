using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public class Category
    {
        private int _id;
        private string _name;

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
    }
}