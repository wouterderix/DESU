using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    public class OccasionBewerken
    {
        public bool occasionBewerken(int history, int version, string title, string description, System.DateTime date, string location, string url)
        {
            var o = new Occasion();
            o.verwijderOccasion(history);
            o.storeOccasion(title, description, date, location, url, false, false, ++version);
            return true;
        }     
    }
}