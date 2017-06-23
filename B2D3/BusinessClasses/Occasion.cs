using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace B2D3.Classes
{
    public partial class Occasion
    {
        public List<Occasion> getOccasions()
        {
            IEnumerable<Occasion> occasionList = new List<Occasion>();

            using (var db = new Casusblok5Model())
            { occasionList = db.Occasions.ToList(); }

            return occasionList.ToList();
        }
        /*
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
        */
    }
}