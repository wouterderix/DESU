using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using B2D3.Classes;
using B2D3.GlobalClasses;

namespace B2D3.DAL
{
    public sealed class ProductRepository : VersionRepository<Product>
    {
        public ProductRepository(DbContext context) : base(context)
        {
            
        }

        public IEnumerable<Product> FilterProducts(Func<Product, bool> filter)
        {
            //Retrieve all latest versions.
            IEnumerable<Product> latestProducts = GetAllLatest();

            //Apply filter and return.
            return filter != null ? latestProducts.Where(filter) : latestProducts;
        }
        public IEnumerable<Product> FilterProducts(ProductQuerryModel searchInstructions)
        {
            IEnumerable<Product> products = GetAllLatestBad();

            //Filter ID
            if (searchInstructions.ID.HasValue)
            { products = products.Where(x => x.HistoryID == searchInstructions.ID); }

            //Filter IsDeleted
            if (searchInstructions.IsDeleted.HasValue)
            { products = products.Where(x => x.IsDeleted == searchInstructions.IsDeleted); }

            //Filter IsApproved
            if (searchInstructions.IsApproved.HasValue)
            { products = products.Where(x => x.IsApproved == searchInstructions.IsApproved); }

            //Filter name
            if (!string.IsNullOrWhiteSpace(searchInstructions.Name))
            { products = products.Where(x => x.Name.ToLower().Contains(searchInstructions.Name.ToLower())); }

            //Filter Min. price
            if (searchInstructions.MinPrice.HasValue)
            { products = products.Where(x => x.Price >= searchInstructions.MinPrice); }

            //Filter Max. price
            if (searchInstructions.MaxPrice.HasValue)
            { products = products.Where(x => x.Price <= searchInstructions.MaxPrice); }

            //Filter Category
            if (searchInstructions.Category != null)
            { products = products.Where(x => x.ProductCategory.Id == searchInstructions.Category.Id); }

            //Filter OperationArea
            if (searchInstructions.OperationAreas != null)
            { products = products.Where(x => x.ProductOperationAreas.Intersect(searchInstructions.OperationAreas).Any()); }

            return products;
        }
    }
}