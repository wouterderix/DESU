using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    public class OccasionGet
    {


        public List<Occasion> getAllOccasions()
        {
            var o = new Occasion();

            o.storeOccasion();
            var ocassions = o.getOccasions(true, false);
            foreach (Occasion ocassion in ocassions)
            {
                Debug.WriteLine(ocassion.Description);
            }
 
            return o.getOccasions(true, true);
        }
    }
}