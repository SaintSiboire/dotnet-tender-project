using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Data
{
    public class InventoryOutputsRepository : BaseRepository<InventoryOutput>
    {
        public InventoryOutputsRepository(Context context)
            :base(context)
        {}

        public override InventoryOutput Get(int id, string userId, bool includeRelatedEntities = true)
        {
            var input = Context.InventoryOutputs.AsQueryable();

            if (includeRelatedEntities)
            {
                input = input
                    .Include(i => i.Inventory);
            }

            return input
                .Where(i => i.Id == id && i.UserId == userId)
                .SingleOrDefault();
        }

        public override IList<InventoryOutput> GetList(string userId)
        {
            var inputs = Context.InventoryOutputs.AsQueryable();

            return inputs
                .OrderBy(i => i.Id)
                .Where(i => i.UserId == userId)
                .ToList();
        }

        public IList<InventoryOutput> GetListByInventory(int id)
        {
            var inputs = Context.InventoryOutputs.AsQueryable();

            return inputs
                .OrderByDescending(i => i.Id)
                .Where(i => i.InventoryId == id)
                .ToList();
        }
    }
}
