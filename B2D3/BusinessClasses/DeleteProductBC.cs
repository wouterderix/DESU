using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using B2D3.Domain;

namespace B2D3.Classes
{
    public class DeleteProductBC
    {
        //get user role
        public bool GetUserRole()
        {
            //implement after login is implemented
            //if user == leverancier or user == supervisor
            return true;

            //else return false;
        }

        //send user role to control class
        public bool PassAlongUserRole()
        {
            return GetUserRole();
        }
    }
}