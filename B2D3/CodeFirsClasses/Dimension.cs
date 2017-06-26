using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2D3
{
    public partial class Dimension
    {
        private int _id;
        private int _length;
        private int _width;
        private int _height;

        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        [Required]
        public int Length
        {
            get
            {
                return _length;
            }

            set
            {
                _length = value;
            }
        }
        [Required]
        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }
        [Required]
        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }
    }
}