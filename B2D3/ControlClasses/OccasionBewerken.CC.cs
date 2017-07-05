using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    /// <summary>
    /// OccasionBewerken
    /// zet oude op 'isdeleted' en voeg nieuwe toe
    /// </summary>
    public class OccasionBewerken
    {
        public bool occasionBewerken(Occasion oldOccasion, string title, string description, System.DateTime date, string location, string url)
        {
            var o = new Occasion();
            o.verwijderOccasion(oldOccasion.HistoryID);
            o.storeOccasion(oldOccasion, title, description, date, location, url);
            return true;
        }

        [Author("Kay Karssing", "occasion goedkeuren doorgeven", Version = 1)]
        public bool occasionGoedkeuren(Occasion oldOccasion, bool IsApproved = true)
        {
            //makes a new instance of Occasion()
            var o = new Occasion();
            //tells occasion to approve the occasion in the database
            o.goedkeuren(oldOccasion, IsApproved);

            //could be used to catch errors
            return true;
        }
    }
}