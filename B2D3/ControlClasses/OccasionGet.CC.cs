using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{

    public class OccasionGet
    {
        public Occasion getOccasion(int history)
        {
            var o = new Occasion();
            return o.getOccasion(history);
        }

        public List<Occasion> getAllOccasions()
        {
            var o = new Occasion();
                      
            var ocassions = o.getOccasions(true, false);
 
            return ocassions;
        }
    }
}