using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    public class OccasionGet
    {
        public List<Occasion> getAllOccasions()
        {
            var o = new Occasion();
            return o.getOccasions();
        }
    }
}