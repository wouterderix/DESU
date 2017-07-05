using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    public class OccasionBewerken
    {
        [Author("Robin Klein", "OccasionBewerken.CC", Version = 1.1f)]
        public bool occasionBewerken(Occasion oldOccasion, string title, string description, System.DateTime date, string location, string url)
        {
            var o = new Occasion();
            //o.storeOccasion(title, description, date, location, url, false, false, ++version);
            o.storeOccasion(oldOccasion, title, description, date, location, url);
            o.verwijderOccasion(oldOccasion.HistoryID);
            return true;
        }

        public bool occasionGoedkeuren(Occasion oldOccasion, bool isApproved = true)
        {
            var o = new Occasion();
            o.ApproveOccasion(oldOccasion, isApproved);
            return true;
        }
    }
}