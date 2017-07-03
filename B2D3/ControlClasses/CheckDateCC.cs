using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using B2D3.Classes;
using System.Data;


namespace B2D3.Classes.CC
{
    public class CheckDateCC
    {
        public DataTable CheckDate()
        {
            CheckDateBC BC = new CheckDateBC();

            return BC.ReturnDates();
        }

        public string DeleteProduct(int id)
        {
            CheckDateBC BC = new CheckDateBC();

            return BC.DeleteByID(id);
        }

        public string ModifyProduct(int id, DateTime date)
        {
            CheckDateBC BC = new CheckDateBC();

            return BC.ModifyByID(id, date);
        }
    }
}