using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    public class OccasionToevoegen
    {
        public bool newOccasion(string title, string description, System.DateTime date, string location, string url, bool deleted = false, bool approved = false, int version = 1)
        {
            var o = new Occasion();
            if(string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(url))
            {
                return false;
            }
            o.storeOccasion(title, description, date, location, url, deleted, approved, version);
            return true; 
        }
    }
}