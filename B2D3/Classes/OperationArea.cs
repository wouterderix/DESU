using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public class OperationArea
    {
        private int _id;
        private string _name;
        private List<Category> _categories;
    
        [Key]
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
        [Index(IsUnique = true), StringLength(100), Required]
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