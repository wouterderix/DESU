using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            newPr.Author = null;
            //newPr. = productVersion;
            //newPr.UserID = userId;

            using (Casusblok5Model context = new Casusblok5Model())
            {
                //try
                //{
                   context.ProductReview.Add(newPr);
                   context.SaveChanges();
                    return true;
                //}
                //catch
                //{
                //    return false;
                //}
            }
        }
    }
}