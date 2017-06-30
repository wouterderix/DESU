using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    public class OccasionGoedkeuren
    {
        public void occasionGoedkeuren(Occasion OldOccasion, bool IsApproved = true)
        {
            var x = new Occasion();
            x.storeOccasion(OldOccasion, OldOccasion.Title, OldOccasion.Description, OldOccasion.Date, OldOccasion.Location, OldOccasion.MoreInformationURL, OldOccasion.IsDeleted, IsApproved, OldOccasion.Version);
            x.verwijderOccasion(OldOccasion.HistoryID);
        }
    }
}