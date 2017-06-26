using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    [Author("Kay Karssing, Jeroen Boesten, Robin Klein", "Occasions.BC", Version = 1.1f)]
    public partial class Occasion
    {
        public List<Occasion> getOccasions(bool showPassedEvents, bool isApproved)
        {
            IEnumerable<Occasion> occasionList = new List<Occasion>();

            // Get all Occasions
            using (var db = new Casusblok5Model())
            { occasionList = db.Occasions.ToList(); }
            // Group by historyID and get the latest version
            occasionList = occasionList.GroupBy(o => o.HistoryID)
                .Select(v => v.OrderByDescending(o => o.Version).FirstOrDefault());
            // If showpassedevents equals false, don't show passedevents
            if (showPassedEvents == false)
            {
                occasionList = occasionList.Where(o => Date >= DateTime.Now.Date);
            }else if(isApproved == true)
            {
                occasionList = occasionList.Where(o => IsApproved == true);
            }else if(isApproved == false)
            {
                occasionList = occasionList.Where(o => IsApproved == false);
            }

            return occasionList.ToList();
        }

        public void storeOccasion()
        {
            var newOccasion = new Occasion();
            using (var db = new Casusblok5Model())
            {
                try
                {
                    //Create a new Occassion
                    newOccasion.Version = 1;
                    newOccasion.Author = db.Users.Include(b => b.AccountRole).FirstOrDefault();
                    newOccasion.IsDeleted = false;
                    newOccasion.Title = "testdata2";
                    newOccasion.Description = "meertestdata2";
                    newOccasion.Date = System.DateTime.Now;
                    newOccasion.Location = "Sittard";
                    newOccasion.moreInformationURL = "www.testdata.nl";
                    newOccasion.IsApproved = false;

                    //Add newOccasion to Occasions
                    db.Occasions.Add(newOccasion);
                    //SaveChanges to database
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }

        /*
        public Occasion getOccasion(int id)
        {
            //Query getOcassion where id = id
            //ocassion = blabla;
            return occasion;
        }

        public void deleteOccasion()
        {
            //Delete occasion
        }
        */
    }
}