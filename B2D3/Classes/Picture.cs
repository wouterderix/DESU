using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public partial class Picture
    {
        private int _id;
        private string _pictureURL;

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
    }
}