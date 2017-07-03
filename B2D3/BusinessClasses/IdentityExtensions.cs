using System.Linq;

namespace B2D3.Classes
{
    [Author("Job Hollands", "Contact Opnemen")]

    //Dit is een extenstie op de Identity
    //Zorgt ervoor dat TOCH het 5-lagen model kan worden toegepast binnen Identity
    public class IdentityExtensions
    {
        //public string GetEmailAdress(string userID)
        //{
        //    using (Casusblok5Model context = new Casusblok5Model())
        //    {
        //        var user = context.AspNetUsers.FirstOrDefault(u => u.Id == userID);

        //        return user.Email;
        //    }
        //}
    }
}