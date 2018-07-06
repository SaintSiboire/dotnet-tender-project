using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Data
{
    public class InventoryInputsRepository : BaseRepository<InventoryInput>
    {
        public InventoryInputsRepository(Context context)
            :base(context)
        {}

        public override InventoryInput Get(int id, string userId, bool includeRelatedEntities = true)
        {
            var input = Context.InventoryInputs.AsQueryable();

            if(includeRelatedEntities)
            {
                input = input
                    .Include(i => i.Inventory);
            }

            return input
                .Where(i => i.Id == id && i.UserId == userId)
                .SingleOrDefault();
        }

        public override IList<InventoryInput> GetList(string userId)
        {
            var inputs = Context.InventoryInputs.AsQueryable();

            return inputs
                .OrderBy(i => i.Id)
                .Where(i => i.UserId == userId)
                .ToList();
        }

        public IList<InventoryInput> GetListByInventory(int id)
        {
            var inputs = Context.InventoryInputs.AsQueryable();

            return inputs
                .OrderBy(i => i.Id)
                .Where(i => i.InventoryId == id)
                .ToList();
        }


    }
}
