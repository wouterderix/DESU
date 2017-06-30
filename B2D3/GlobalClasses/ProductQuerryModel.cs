using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using B2D3.Classes;

namespace B2D3.GlobalClasses
{
    public struct ProductQuerryModel
    {
        /// <summary>
        /// The ID of the product.
        /// </summary>
        public int? ID
        { get; set; }
        /// <summary>
        /// The name of the product. Matches by 'contains'
        /// </summary>
        public string Name
        { get; set; }
        /// <summary>
        /// The approval state of the product.
        /// </summary>
        public bool? IsApproved
        { get; set; }
        /// <summary>
        /// The minimal price to search for.
        /// </summary>
        public decimal? MinPrice;
        /// <summary>
        /// The maximum price to search for.
        /// </summary>
        public decimal? MaxPrice;
        /// <summary>
        /// The category containing this product.
        /// </summary>
        public Category Category
        { get; set; }
        /// <summary>
        /// A collection of operation areas containing this product.
        /// </summary>
        public List<OperationArea> OperationAreas
        { get; set; }
        /// <summary>
        /// Show deleted products or not.
        /// </summary>
        public bool? IsDeleted
        { get; set; }

        /// <summary>
        /// Returns a querrymodel for approved and existing products.
        /// </summary>
        /// <returns></returns>
        public static ProductQuerryModel ViewableProducts()
        { return new ProductQuerryModel() { IsDeleted = false, IsApproved = true }; }
    }
}