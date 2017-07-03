using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace B2D3.Classes
{
    public partial class ProductReview
    {
        public ProductReview() { }

        public bool Insert(string reviewText, int starRatingInt, DateTime reviewDate,
                bool anonymous, int productID, int productVersion, int? userId)
        {
            ProductReview newPr = new ProductReview();
            newPr.ReviewText = reviewText;
            newPr.StarRating = starRatingInt;
            newPr.ReviewDate = reviewDate;
            newPr.IsAnonymous = anonymous;
            //newPr. = productID;
            //newPr. = productVersion;
            //newPr.Author = ;
            //newPr.UserID = userId;

            using (Casusblok5Model context = new Casusblok5Model())
            {
                newPr.Author = context.Users.Include(b => b.AccountRole).FirstOrDefault();//Omdat GetUser niet is geïmplementeeerd
                // wordt hier de eerste user uit de database gepakt
                try
                {
                   context.ProductReview.Add(newPr);
                   context.SaveChanges();
                   return true;
                }
                catch
                {
                   return false;
                }
            }
        }
    }
}