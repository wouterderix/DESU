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

        /// <summary>
        /// The available IServable instance.
        /// </summary>
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

        [Author("Dennis Corvers, Damien Brils", "ProductZoeken", Version = 1)]
        /// <summary>
        /// Search for products matching specified filter options.
        /// </summary>
        /// <param name="searchInstructions">Filter options to search by.</param>
        /// <returns></returns>
        public List<Product> SearchProducts(ProductQuerryModel searchInstructions)
        {
            //Check logged in?
            //Check authorisation?

            return _databaseAccess.SearchProducts(searchInstructions);
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
            return _databaseAccess.GetNews();
        }

        public News GetNewsArticle(int newsID)
        {
            return _databaseAccess.GetNewsArticle(newsID);
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