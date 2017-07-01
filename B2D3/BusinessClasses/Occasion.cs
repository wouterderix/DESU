using B2D3.DAL;
using B2D3.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    [Author("Kay Karssing, Jeroen Boesten, Robin Klein", "Occasions.BC", Version = 1.1f)]
    public partial class Occasion
    {
        /// <summary>
        /// Gets the occasions.
        /// </summary>
        /// <param name="showPassedEvents">if set to <c>true</c> show [passed events].</param>
        /// <param name="isApproved">if set to <c>true</c> show [is approved].</param>
        /// <returns></returns>
        public List<Occasion> getOccasions(bool showPassedEvents, bool isApproved)
        {
            IEnumerable<Occasion> occasionList = new List<Occasion>();

            // Get all Occasions
            using (var db = new Casusblok5Model())
            {
                occasionList = db.Occasions.ToList();
            }
            // Group by historyID and get the latest version
            occasionList = occasionList.Where(o => o.IsDeleted == false)
                .GroupBy(o => o.HistoryID)
                .Select(v => v.OrderByDescending(o => o.Version).FirstOrDefault());
            // If showpassedevents equals false, don't show events that have passed
            if (showPassedEvents == false)
            {
                occasionList = occasionList.Where(o => o.Date > DateTime.Now.Date);
            }
            //Only show Events that have been approved by a supervisor
            else if (isApproved == true)
            {
                occasionList = occasionList.Where(o => o.IsApproved == true);
            }
            //Only show Events that have not been approved by a supervisor
            else if (isApproved == false)
            {
                occasionList = occasionList.Where(o => o.IsApproved == false);
            }

            return occasionList.ToList();
        }

        /// <summary>
        /// Stores a new occasion.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="desription">The desription.</param>
        /// <param name="date">The date.</param>
        /// <param name="location">The location.</param>
        /// <param name="url">The URL.</param>
        /// <param name="deleted">if set to <c>true</c> [deleted].</param>
        /// <param name="approved">if set to <c>true</c> [approved].</param>
        /// <param name="version">The version.</param>
        public void storeOccasion(string title, string desription, System.DateTime date, string location, string url, bool deleted = false, bool approved = false, int version = 1)
        {
            var newOccasion = new Occasion();
            using (var db = new Casusblok5Model())
            {
                //Create a new Occassion with all the information
                newOccasion.HistoryID = db.History.Max(h => h.HistoryID) + 1;
                newOccasion.Version = version;
                newOccasion.Author = db.Users.Include(b => b.AccountRole).FirstOrDefault(); //!!To be replaced with logged in User!!
                newOccasion.IsDeleted = deleted;
                newOccasion.Title = title;
                newOccasion.Description = desription;
                newOccasion.Date = date;
                newOccasion.Location = location;
                newOccasion.moreInformationURL = url;
                newOccasion.IsApproved = IsApproved;

                //Add newOccasion to Occasions
                db.Occasions.Add(newOccasion);
                //SaveChanges to database
                db.SaveChanges();

            }
        }

        /// <summary>
        /// Creates a new version from a OldOccasion
        /// </summary>
        /// <param name="oldOccasion">The old occasion.</param>
        /// <param name="title">The title.</param>
        /// <param name="desription">The desription.</param>
        /// <param name="date">The date.</param>
        /// <param name="location">The location.</param>
        /// <param name="url">The URL.</param>
        /// <param name="deleted">if set to <c>true</c> [deleted].</param>
        /// <param name="approved">if set to <c>true</c> [approved].</param>
        /// <param name="version">The version.</param>
        public void storeOccasion(Occasion oldOccasion, string title, string desription, System.DateTime date, string location, string url, bool deleted = false, bool approved = false, int version = 1)
        {

            using (var db = new Casusblok5Model())
            {

                //Create a new Occassion
                var Author = db.Users.Include(b => b.AccountRole).FirstOrDefault(); //!!To be replaced with logged in User!!
                var newOccasion = new Occasion(oldOccasion, Author, false);
                newOccasion.HistoryID = oldOccasion.HistoryID;
                newOccasion.IsDeleted = deleted;
                newOccasion.Title = title;
                newOccasion.Description = desription;
                newOccasion.Date = date;
                newOccasion.Location = location;
                newOccasion.moreInformationURL = url;
                newOccasion.IsApproved = IsApproved;

                //Add newOccasion to Occasions
                db.Occasions.Add(newOccasion);
                //SaveChanges to database
                db.SaveChanges();
            }
        }

        public Occasion getOccasion(int history)
        {
            using (var db = new Casusblok5Model())
            {
                return (from o in db.Occasions
                        where o.HistoryID == history
                        select o).OrderByDescending(o => o.Version).FirstOrDefault();
            }
        }

        public bool verwijderOccasion(int history)
        {
            //Query getOcassion where id = id && version = version
            using (var db = new Casusblok5Model())
            {

                var occasion = getOccasion(history);

                if (occasion != null)
                {
                    occasion.IsDeleted = true;
                    occasion.Author = db.Users.Include(b => b.AccountRole).FirstOrDefault();
                    db.Occasions.AddOrUpdate(occasion);
                    db.SaveChanges();
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }
    }
}