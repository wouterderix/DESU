﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using B2D3.Classes;

namespace B2D3.Classes.CC
{
    /// <summary>
    /// behoort tot UC Product verwijderen
    /// gemaakt door Rowan Koenen
    /// </summary>

    public class DeleteProductCC
    {
        Domain.DeleteProductDAL DeleteProductDataAccessLayer = new Domain.DeleteProductDAL();
        DeleteProductBC DeleteProductBusinessLayer = new DeleteProductBC();

        public bool PassAlongProducts(string name)
        {
            if (DeleteProductBusinessLayer.PassAlongUserRole())
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

            else return false;
        }
    }
}