using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using B2D3.Classes;
using B2D3.GlobalClasses;

namespace B2D3.DAL
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
            using (var db = new Casusblok5Model())
            {
                var getNews = (from n in db.News
                               orderby n.HistoryID descending
                               select n).ToList<News>();

                return getNews;
            }
        }

        public News GetNewsArticle(int newsID)
        {
            using (var db = new Casusblok5Model())
            {
                var getNewsArticle = (from n in db.News
                                      where n.HistoryID == newsID
                                      select n).FirstOrDefault<News>();

                return getNewsArticle;
            }
        }

        public Occasion[] GetOccasions(bool showPassedEvents)
        {
            throw new NotImplementedException();
        }

        [Author("Dennis Corvers, Damien Brils", "ProductZoeken", Version = 1.1f)]
        /// <summary>
        /// Search for products matching specified filter options.
        /// </summary>
        /// <param name="searchInstructions">Filter options to search by.</param>
        /// <returns></returns>
        public List<Product> SearchProducts(ProductQuerryModel searchInstructions)
        {
            IEnumerable<Product> products = new List<Product>();

            using (var db = new Casusblok5Model())
            {

                var result = db.Products.GroupBy(p => p.HistoryID).Select(group => new { prod = group.OrderByDescending(p => p.Version).ElementAtOrDefault(0) });

                foreach(var prod in result)
                {
                    var producterino = prod.prod;
                }
                return products.ToList();
            }


                //Gets the latest version of every product.
                products = products.GroupBy(p => p.HistoryID)
                    .Select(v => v.OrderByDescending(p => p.Version).FirstOrDefault());


            //Filter IsDeleted
            if (searchInstructions.IsDeleted.HasValue)
            { products = products.Where(x => x.IsDeleted == searchInstructions.IsDeleted); }

            //Filter IsApproved
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

            //Filter Category
            if (searchInstructions.Category != null)
            { products = products.Where(x => x.ProductCategory.Id == searchInstructions.Category.Id); }

            //Filter OperationArea
            if (searchInstructions.OperationAreas != null)
            { products = products.Where(x => x.ProductOperationAreas.Intersect(searchInstructions.OperationAreas).Any()); }

            return products.ToList();
        }
    }
}