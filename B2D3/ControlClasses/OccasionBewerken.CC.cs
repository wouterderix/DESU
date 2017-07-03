using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    public class OccasionBewerken
    {
        public bool occasionBewerken(Occasion oldOccasion, string title, string description, System.DateTime date, string location, string url)
        {
            var o = new Occasion();
            o.verwijderOccasion(oldOccasion.HistoryID);
            o.storeOccasion(oldOccasion, title, description, date, location, url);
            return true;
        }
        
        public bool occasionGoedkeuren(Occasion oldOccasion, bool IsApproved = true)
        {
            var o = new Occasion();
            o.goedkeuren(oldOccasion, IsApproved);

            return true;
        }
    }
}