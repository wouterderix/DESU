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
            _operationAreaDict = new Dictionary<int, OperationArea>();
            _categoryDict = new Dictionary<int, Category>();
            _accountRoleDict = new Dictionary<int, AccountRole>();
        }

        public OperationArea GetOperationArea(int id)
        {
            throw new NotImplementedException();
        }
        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }
        public AccountRole GetAccountRole(int id)
        {
            throw new NotImplementedException();
        }

        public List<OperationArea> GetOperationAreas()
        {
            return new List<OperationArea>(_operationAreaDict.Values);
        }
        public List<Category> GetCategories()
        {
            return new List<Category>(_categoryDict.Values);
        }
        public List<AccountRole> GetAccountRoles()
        {
            return new List<AccountRole>(_accountRoleDict.Values);
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

        /// <summary>
        /// Search for products matching specified filter options.
        /// </summary>
        /// <param name="searchInstructions">Filter options to search by.</param>
        /// <returns></returns>
        public List<Product> SearchProducts(ProductQuerryModel searchInstructions)
        {
            List<Product> returnList = new List<Product>();

            using (var db = new Casusblok5Model())
            {
                //Retrieves the latest version of products for products that aren't deleted.
                var products = (db.Products.GroupBy(p => p.ID)
                                  .Select(g => g.OrderByDescending(p => p.Version)
                                                .FirstOrDefault()).Where(x => !x.IsDeleted)
                                   );

                //Filter approval
                if (searchInstructions.IsApproved.HasValue)
                { products = products.Where(x => x.IsApproved == searchInstructions.IsApproved); }

                //Filter name
                if (!string.IsNullOrWhiteSpace(searchInstructions.Name))
                { products = products.Where(x => x.Name.ToLower().Contains(searchInstructions.Name.ToLower())); }

                //Filter Min. price
                if (searchInstructions.MinPrice.HasValue)
                { products = products.Where(x => x.Price >= searchInstructions.MinPrice); }

                //Filter Max. price
                if (searchInstructions.MaxPrice.HasValue)
                { products = products.Where(x => x.Price <= searchInstructions.MaxPrice); }











                returnList.AddRange(products);
            }

            //var star = from t in table
            //           let maxVersion = (
            //             from v in table
            //             where v.name == "name"
            //             orderby v.version descending
            //             select v.version).FirstOrDefault()
            //           where t.name == "name" && t.version == maxVersion
            //           select t;

            return returnList;
        }
    }
}