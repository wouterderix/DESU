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
        
         /*
         getNotApproved haalt alle database entries op die nog niet 
         geweest zijn en nog niet goedgekeurd zijn.
         
         deze worden teruggegeven in de vor van objecten die alle
         eigenschappen van de occasion bevatten
         */
        public List<Occasion> getNotApproved()
        {
            var o = new Occasion();

            return o.getOccasions(true, false);
        }

    }
}