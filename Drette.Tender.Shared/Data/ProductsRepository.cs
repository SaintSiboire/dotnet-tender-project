﻿using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Data
{
    public class ProductsRepository : BaseRepository<Product>
    {
        public ProductsRepository(Context context)
            :base(context)
        {
        }

        public Product Get(int id, string userId, bool includeRelatedEntities = true)
        {
            var product = Context.Products.AsQueryable();

            if(includeRelatedEntities)
            {
                product = product
                    .Include(p => p.Inventory)
                    .Include(p => p.Supplier)
                    .Include(p => p.ProductType);
            }

            return product
                    .Where(p => p.Id == id && p.UserId == userId)
                    .SingleOrDefault();
        }

        public IList<Product> GetList(string userId)
        {
            return Context.Products
                        .Include(p => p.Inventory)
                        .Include(p => p.Supplier)
                        .Include(p => p.ProductType)
                        .Where(p => p.UserId == userId)
                        .OrderBy(p => p.InventoryId)
                        .ToList();
        }
    }
}