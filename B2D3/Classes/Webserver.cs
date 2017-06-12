using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public sealed class Webserver : IServable
    {
        private static Webserver _instance;
        private static readonly object _instanceLock = new object();
        private static DatabaseAccess _databaseAccess;
        public static IServable Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null) { _instance = new Webserver(); }
                    return _instance;
                }
            }
        }


        private Webserver()
        { _databaseAccess = new DatabaseAccess(); }


        public List<Product> SearchProducts(ProductQuerryModel searchInstructions)
        {
            throw new NotImplementedException();
        }

        public bool ApproveOccasion(int occasionID, bool isApproved)
        {
            throw new NotImplementedException();
        }

        public bool ApproveProduct(int productID, bool isApproved)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public Occasion[] GetOccasions(bool showPassedEvents)
        {
            throw new NotImplementedException();
        }

        public List<News> GetNews()
        {
            throw new NotImplementedException();
        }

        public List<News> GetNewsArticle(int newsID)
        {
            throw new NotImplementedException();
        }

        public void AddNews(string title, string content, string image)
        {
            throw new NotImplementedException();
        }

        public bool CheckDate(DateTime currentDate, DateTime expirationDate)
        {
            throw new NotImplementedException();
        }

        public DataTable GetData(DateTime startDate)
        {
            throw new NotImplementedException();
        }

        public static bool IsLoggedIn()
        {
            throw new NotImplementedException();
        }
        public static bool IsAuthorized(AccountRole minAccountRole)
        {
            throw new NotImplementedException();
        }
        public static User GetCurrentUser()
        {
            throw new NotImplementedException();
        }
    }
}