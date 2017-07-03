using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using B2D3.Classes;

namespace B2D3.Classes.CC
{
    public class ReviewProduct
    {
        public bool PlaceReview(string ReviewText, string StarRating, DateTime ReviewDate,
            bool Anonymous, int ProductID, int ProductVersion, int? userID)
        {
            // Als het anoniem-vinkje is gecheckt, wordt userID op null gezet, zodat er binnen de database 
            // geen link is tussen een review en een gebruiker.
            if (Anonymous)
            {
                userID = null;
            }
            if (StarRating == string.Empty)
            {
                StarRating = "0";
            }
            // Als er geen starrating wordt aangevinkt wordt de variabele StarRating op 0 gezet in het if-statement hierboven.
            // Hieronder wordt de startrating geconverteerd naar een integer.
            int StarRatingInt = Int32.Parse(StarRating);

            ProductReview pr = new ProductReview();
            return pr.Insert(ReviewText, StarRatingInt, ReviewDate,
                Anonymous, ProductID, ProductVersion, userID);
        }
    }
}