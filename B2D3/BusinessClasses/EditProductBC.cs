using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace B2D3.Classes
{
    public partial class Product
    {
        /// <summary>
        /// Get all products where isdeleted = False
        /// </summary>
        /// <returns></returns>
        /*
        public List<Product> CheckProduct()
        {
            var pqm = new B2D3.Classes.ProductQuerryModel() { IsDeleted = false };
            var resultSet = ControlClasses.SearchProduct.QuerryProducts(pqm);

            return resultSet;
        }
        */
    }
    //public DataTable ReturnProducts()
    //{
    //    Product p = new Product();
    //    Array productArray;
    //    productArray = p.CheckDate();

    //    dt = new DataTable();

    //    for (int i = 0; i < productArray.Length; i++)
    //    {
    //        Dictionary<string, object> dict = DataDictProperties.DictionaryFromType(productArray.GetValue(i));
    //        if (i == 0)
    //        {
    //            foreach (KeyValuePair<String, object> kvp in dict)
    //            {
    //                dt.Columns.Add(kvp.Key);    // Kolomen benoemen 
    //            }
    //        }
    //        DataRow dr = dt.NewRow();
    //        foreach (KeyValuePair<String, object> kvp in dict)
    //        {
    //            dr[kvp.Key] = kvp.Value;        // Waarden aan de kolommen toevoegen
    //        }


    //        dt.Rows.Add(dr);

    //    }

    //    return dt;
    //}
}
