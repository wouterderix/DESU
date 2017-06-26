using B2D3.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.ControlClasses
{
    public class GetNewsCC
    {
        private static News newsC = new News();

        public List<News> GetNews()
        {
            return newsC.Getnews();
        }
    }
}