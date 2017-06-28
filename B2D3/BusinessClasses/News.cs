using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public partial class News
    {
        public List<News> GetNews()
        {
            List<News> news = Webserver.Instance.GetNews();

            if (news.Count > 10)
            {
                news = news.GetRange(0, 10);
            }

            return news;
        }

        public News GetNewsArticle(int NewsID)
        {
            return Webserver.Instance.GetNewsArticle(NewsID);
        }
    }
}