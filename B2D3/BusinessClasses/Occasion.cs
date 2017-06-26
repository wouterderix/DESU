using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace B2D3.Classes
{
    public partial class Occasion
    {
        public List<Occasion> getOccasions(bool showPassedEvents, bool isApproved)
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
            }if(isApproved == true)
            {
                occasionList = occasionList.Where(o => IsApproved == true);
            }else if(isApproved == false)
            {
                occasionList = occasionList.Where(o => IsApproved == false);
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