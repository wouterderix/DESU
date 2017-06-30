using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using B2D3.GlobalClasses;

namespace B2D3.Classes
{
    [Author("Robin Jongen", "ProductAanpassen", Version = 0.1f)]
    public partial class Product
    {
        /// <summary>
        /// Get all products where isdeleted = False
        /// </summary>
        /// <returns></returns>
        
        public DataTable CheckProduct()
        {
            var pqm = new ProductQuerryModel() { IsDeleted = false };
            var resultSet = ControlClasses.SearchProduct.QuerryProducts(pqm);
            return resultSet;
        }
        public DataTable CheckSingleProduct(int ID1, int Version)
        {
            var pqm = new ProductQuerryModel() { ID = ID1, IsDeleted = false };
            var resultSet = ControlClasses.SearchProduct.QuerryProducts(pqm);
            return resultSet;
        }
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
