using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using B2D3.Classes;


namespace B2D3.Classes
{
    public partial class Occasion
    {
        public string test1()
        {
            return "test";
        }



        public List<Occasion> getMultipleOccasion(bool isDeleted)
        {
            List<Occasion> occasionList = null;

            IEnumerable<Occasion> OccasionQuerry =
                from Occasion in Classes
                where IsDeleted = isDeleted
                select Occasion;

            
            foreach (Occasion occasion in OccasionQuerry) {
                occasionList.Add(occasion);
            }

            return occasionList;
        }

        //public Occasion getOccasion(int id)
        //{
        //    IEnumerable<Occasion> OccasionQuerry =
        //        from Occasion in Classes
        //        where 
        //        select Occasion;

        //    return occasion;
        //}

        public void deleteOccasion()
        {
            //Delete occasion
        }
    }
}