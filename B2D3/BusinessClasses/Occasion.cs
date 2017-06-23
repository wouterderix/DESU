using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace B2D3.Classes
{
    public partial class Occasion
    {
        public string test1()
        {
            return "test";
        }



        public List<Occasion> getOccasion()
        {
            //Query getOccasion
            return occasionList;
        }

        public Occasion getOccasion(int id)
        {
            //Query getOcassion where id = id
            //ocassion = blabla;
            return occasion;
        }

        public void deleteOccasion()
        {
            //Delete occasion
        }
    }
}