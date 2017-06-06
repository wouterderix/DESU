using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.BU
{
    public partial class Product
    {
        public int ID { get; set; }
        public int Version { get; set; }
        public int Quantity { get; set; }
        public int timesViewed { get; set; }
        public int Price { get; set; }
        public int categoryID { get; set; }
        public int supplierID { get; set; }
        public int areaID { get; set; }
        public int infoID { get; set; }

        public string Name { get; set; }
        
        public bool isApproved { get; set; }
        public bool Compensation { get; set; }
        
    }
}