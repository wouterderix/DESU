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

        public int UseCaseNumber;
        public float Version;

        public AuthorAttribute(string author, string useCase)
        {
            _author = author;
            _useCase = useCase;   
        }
    }
}