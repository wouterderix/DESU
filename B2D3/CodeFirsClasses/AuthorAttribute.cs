using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple =true, Inherited =true)]
    public class AuthorAttribute : Attribute
    {
        private string _author;
        private string _useCase;

        public int UseCaseNumber { get; set; }
        public float Version { get; set; }
        public bool IsAfgekeurd { get; set; }
        public string Author
        {
            get
            {
                return _author;
            }

            private set
            {
                _author = value;
            }
        }
        public string UseCase
        {
            get
            {
                return _useCase;
            }

            private set
            {
                _useCase = value;
            }
        }

        public AuthorAttribute(string author, string useCase)
        {
            Author = author;
            UseCase = useCase;   
        }
    }
}