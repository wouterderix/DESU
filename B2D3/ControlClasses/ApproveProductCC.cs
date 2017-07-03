using B2D3.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace B2D3.ControlClasses
{
    public class ApproveProduct
    {
        public bool ApprovedProduct(int historyID, int versionID)
        {
            return new Product().Approve(historyID, versionID);
        }

        public DataTable getDataTable()
        {
            var DT = new Product();
            return DT.GetAllProductNotApproved();
        }
    }
}