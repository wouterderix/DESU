using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace B2D3.Classes.CC
{
    public class OccasionToevoegen
    {
        /// <summary>
        /// Sends data to store newOccasion in BusinessClass and checks for empty fields
        /// Also in the future this method should handle if User is not correctly logged in or to low for action
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="date">The date.</param>
        /// <param name="location">The location.</param>
        /// <param name="url">The URL.</param>
        /// <param name="deleted">if set to <c>true</c> [deleted].</param>
        /// <param name="approved">if set to <c>true</c> [approved].</param>
        /// <param name="version">The version.</param>
        /// <returns></returns>
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