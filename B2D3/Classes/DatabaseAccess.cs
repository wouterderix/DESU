using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public class DatabaseAccess : IStorable
    {
        private Dictionary<int, OperationArea> _operationAreaDict;
        private Dictionary<int, Category> _categoryDict;
        private Dictionary<int, AccountRole> _accountRoleDict;


        public DatabaseAccess()
        {

        }


        public void AddNews(string title, string content, string image)
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

        public bool CheckDate(DateTime currentDate, DateTime expirationDate)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public DataTable GetData(DateTime startDate)
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

        public Occasion[] GetOccasions(bool showPassedEvents)
        {
            throw new NotImplementedException();
        }

        public List<Product> SearchProducts(ProductQuerryModel searchInstructions)
        {
            throw new NotImplementedException();
        }
    }
}