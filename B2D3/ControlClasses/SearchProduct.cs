﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using B2D3.BusinessClasses;
using B2D3.Classes;
using B2D3.GlobalClasses;
using FastMember;
using System.ComponentModel;
using System.Reflection;

namespace B2D3.ControlClasses
{
    [Author("Dennis Corvers, Damien Brils", "ProductZoeken", Version = 1.2f)]
    public static class SearchProduct
    {

        //5 lagen model toepassen! Business Class, Control Class en DataAccesLayer Class

        /// <summary>
        /// Search for a product by name only.
        /// </summary>
        /// <param name="productName">The product name to search for.</param>
        /// <returns></returns>
        public static DataTable SearchByName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            { throw new ArgumentException("Product name may not be empty!"); }

            ProductQuerryModel p = ProductQuerryModel.ViewableProducts(); p.Name = productName;
            return ExecuteProductQuerry(p);
        }

        /// <summary>
        /// Fetch all products belonging to one category.
        /// </summary>
        /// <param name="category">The category to search for.</param>
        /// <returns></returns>
        public static DataTable SearchByCategory(Category category)
        {
            if (category == null) { throw new ArgumentNullException("Category may not be null!"); }

            ProductQuerryModel p = ProductQuerryModel.ViewableProducts(); p.Category = category;
            return ExecuteProductQuerry(p);
        }

        /// <summary>
        /// Fetch all products belonging to one operation area.
        /// </summary>
        /// <param name="operationArea">The operation area to search for.</param>
        /// <returns></returns>
        public static DataTable SearchByOperationArea(OperationArea operationArea)
        {
            if (operationArea == null) { throw new ArgumentNullException("OperationArea may not be null!"); }

            return SearchByOperationArea(new List<OperationArea> { operationArea });
        }
        /// <summary>
        /// Fetch all products belonging to one of the specified operation areas.
        /// </summary>
        /// <param name="operationArea">A set of operation areas to search for</param>
        /// <returns></returns>
        public static DataTable SearchByOperationArea(List<OperationArea> operationArea)
        {
            if (operationArea == null) { throw new ArgumentNullException("OperationArea may not be null!"); }

            ProductQuerryModel p = ProductQuerryModel.ViewableProducts(); p.OperationAreas = operationArea;
            return ExecuteProductQuerry(p);
        }

        /// <summary>
        /// Fetch every product available.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllProducts()
            => ExecuteProductQuerry(ProductQuerryModel.ViewableProducts());

        /// <summary>
        /// Search for a product with a custom filter.
        /// </summary>
        /// <param name="productQuerry">The filter options to search by.</param>
        /// <returns></returns>
        public static DataTable QuerryProducts(ProductQuerryModel productQuerry)
            => ExecuteProductQuerry(productQuerry);

        private static DataTable ExecuteProductQuerry(ProductQuerryModel productQuerry)
        { return DatatableBuilder.BuildDatatable(Webserver.Instance.SearchProducts(productQuerry)); }
    }
}