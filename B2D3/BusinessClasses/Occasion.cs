using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;


namespace B2D3.Classes
{
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
            }if(isApproved == true)
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
            Occasion newOccasion = new Occasion();

            //Test
            User testUser = new User();
            // Get First User
            using (var db = new Casusblok5Model())
            { testUser = db.Users.First(); }
            // Test done

            newOccasion.Version = 1;
            newOccasion.Author = testUser;
            newOccasion.IsDeleted = false;
            newOccasion.Title = "testdata1";
            newOccasion.Description = "meertestdata1";
            newOccasion.Date = System.DateTime.Now;
            newOccasion.Location = "Sittard";
            newOccasion.moreInformationURL = "www.testdata.nl";
            newOccasion.IsApproved = false;
        
            using (var db = new Casusblok5Model())
            {
                try
                {
                    db.Occasions.Add(newOccasion);
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