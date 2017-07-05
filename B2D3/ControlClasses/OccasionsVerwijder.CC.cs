using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    [Author("Robin Klein", "OccasionBewerken.CC", Version = 1.1f)]
    public class OccasionsVerwijder
    {
        public void verwijderOccasion(int history)
        {
            var o = new Occasion();
            o.verwijderOccasion(history);
        }
    }
}