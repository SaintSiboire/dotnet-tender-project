using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Data
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(Context context)
            :base(context)
        {
        }

        public override Product Get(int id, bool includeRelatedEntities = true)
        {
            var product = Context.Products.AsQueryable();

            if(includeRelatedEntities)
            {
                product = product
                    .Include(p => p.Inventory);
            }

            return product
                    .Where(p => p.Id == id)
                    .SingleOrDefault();
        }

        public override IList<Product> GetList()
        {
            return Context.Products
                        .AsNoTracking()
                        .OrderBy(p => p.InventoryId)
                        .ToList();
        }
    }
}
