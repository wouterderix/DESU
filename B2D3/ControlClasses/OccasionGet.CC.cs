using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{

    public class OccasionGet
    {
        public List<string> Doorgeefinfo = null;

        public void doorgeefID(int history, int version, string title)
        {
            Doorgeefinfo.Add(history.ToString());
            Doorgeefinfo.Add(version.ToString());
            Doorgeefinfo.Add(title);
        }

        public Occasion getOccasion(/*int history, int version,*/ string title)
        {
            var o = new Occasion();
            return o.getOccasion(/*history, version,*/ title);
        }

        public List<Occasion> getAllOccasions()
        {
            var o = new Occasion();
                      
            var ocassions = o.getOccasions(true, false);
 
            return ocassions;
        }
    }
}