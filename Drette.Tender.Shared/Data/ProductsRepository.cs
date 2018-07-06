using Drette.Tender.Shared.Models;
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

        public override Product Get(int id, string userId, bool includeRelatedEntities = true)
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

        public Product GetByProductCode(string productCode)
        {
            var product = Context.Products.AsQueryable();

            return product
                .Include(p => p.Inventory)
                .Include(p => p.Supplier)
                .Include(p => p.ProductType)
                .Where(p => p.ProductCode == productCode)
                .SingleOrDefault();                
        }

        public override IList<Product> GetList(string userId)
        {
            return Context.Products
                        .Include(p => p.Inventory)
                        .Include(p => p.Supplier)
                        .Include(p => p.ProductType)
                        .Where(p => p.UserId == userId)
                        .OrderBy(p => p.InventoryId)
                        .ToList();
        }

        public IList<Product> GetAll()
        {
            return Context.Products
                        .Include(p => p.Inventory)
                        .Include(p => p.Supplier)
                        .Include(p => p.ProductType)
                        .OrderBy(p => p.ProductCode)
                        .ToList();
        }
    }
}
