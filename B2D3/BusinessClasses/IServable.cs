using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2D3.Classes;
using B2D3.GlobalClasses;

namespace B2D3.BusinessClasses
{
    public interface IServable
    {
        List<Product> SearchProducts(ProductQuerryModel searchInstructions);

        bool ApproveOccasion(int occasionID, bool isApproved);

        bool ApproveProduct(int productID, bool isApproved);

        void DeleteProduct();

        Occasion[] GetOccasions(bool showPassedEvents);

        List<News> GetNews();

        News GetNewsArticle(int newsID);

        void AddNews(string title, string content, string image);

        bool CheckDate(DateTime currentDate, DateTime expirationDate);

        System.Data.DataTable GetData(DateTime startDate);
    }
}
