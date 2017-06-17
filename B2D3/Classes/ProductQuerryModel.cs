using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public struct ProductQuerryModel : ISearchable
    {
        public int? ID;
        public string Name;
        public bool? IsApproved;
        public decimal? MinPrice;
        public decimal? MaxPrice;
        public List<Category> Categories;
        public List<OperationArea> OperationAreas;
        //etc...
    }
}