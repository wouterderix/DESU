using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    /// <summary>
    /// zet occasion 'isdelete' op true / 1
    /// </summary>
    public class OccasionsVerwijder
    {
        public void verwijderOccasion(int history)
        {
            var o = new Occasion();
            o.verwijderOccasion(history);
        }
    }
}