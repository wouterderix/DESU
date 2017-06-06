using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2D3.BU
{
    public partial class DeleteProduct
    {
        public void searchProduct(string name)
        {
            using (B2D3Container context = new B2D3Container())
            {
                IQueryable<Product> prod = context.Product;

                Product[] productArray = (
                                            from p in product
                                            where p.name == name
                                            select p
                                         ).ToArray();
                
                foreach (Product item in Array productArray)
                {
                    item.Remove();
                }
            }
        }
    }
}