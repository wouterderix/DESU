using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace B2D3.Classes
{
    public partial class Occasion
    {
        DateTime currentDateTime = DateTime.Now;
        public List<Occasion> getOccasions(bool showPassedEvents)
        {
            IEnumerable<Occasion> occasionList = new List<Occasion>();

            // Get all Occasions
            using (var db = new Casusblok5Model())
            { occasionList = db.Occasions.ToList(); }
            // Group by historyID and get the latest version
            occasionList = occasionList.GroupBy(o => o.HistoryID)
                .Select(v => v.OrderByDescending(o => o.Version).FirstOrDefault());
            // If showpassedevents equals false, don't show passedevents
            if (showPassedEvents == false)
            {
                occasionList = occasionList.Where(o => Date >= DateTime.Now.Date);
            }

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