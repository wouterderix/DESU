using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using B2D3.Classes;
using System.Data;

namespace B2D3.Classes.CC
{
    [Author("Jens Koekkoek, Xavier van Egdom", "NieuwsInzien")]
    public class GetNewsCC
    {
        public DataTable GetNews(int takeCount = 10)
        {
            return new News().SearchNews(takeCount);
        }

        public News GetNewsByID(int newsID)
        {
            return new News().GetNewsByID(newsID);
        }
    }
}