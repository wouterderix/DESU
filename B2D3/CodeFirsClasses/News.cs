using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    [Table("News")]
    public partial class News : History
    {
        private string _title;
        private string _description;
        private DateTime _dueDate;


        public News(News oldVersion, User author, bool isDeleted)
            : base(oldVersion, author, isDeleted)
        {
        }
        public News(User author, bool isDeleted)
            : base(author, isDeleted)
        {
        }

        [Index(IsUnique = true), StringLength(255), Required]
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

        public News() { }

        public List<News> Getnews()
        {
            using (Casusblok5Model db = new Casusblok5Model())
            {
                return db.News.ToList();
            }
        }
    }
}