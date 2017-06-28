using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    public class OccasionsVerwijder
    {
        public void verwijderOccasion(/*int history, int version,*/ string title)
        {
            var o = new Occasion();
            o.verwijderOccasion(/*history, version,*/ title);
        }
    }
}