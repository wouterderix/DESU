using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace B2D3.ControlClasses
{
    /// <summary>
    /// behoort tot UC Product verwijderen
    /// gemaakt door Rowan Koenen
    /// </summary>

    public class DeleteProductCC
    {
        Domain.DeleteProductDAL DeleteProductDataAccessLayer = new Domain.DeleteProductDAL();

        public bool PassAlongProducts(string name)
        {
            //receive product name from UI and pass it to delete class, returns error if false
            if (DeleteProductDataAccessLayer.DeleteProduct(name))
            {
                //noError
                return true;
            }

            else
            {
                //yesError
                return false;
            }
        }
    }
}