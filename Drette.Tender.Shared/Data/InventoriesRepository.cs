using System;
using System.Collections.Generic;
using System.Linq;
using Drette.Tender.Shared.Models;

namespace Drette.Tender.Shared.Data
{
    /// <summary>
    /// Repository for items.
    /// </summary>
    public class InventoriesRepository : BaseRepository<Inventory>
    {
        public InventoriesRepository(Context context) 
            : base(context)
        {
        }

        public override Inventory Get(int id, bool includeRelatedEntities = true)
        {
            var inventory = Context.Inventories
                .Where(i => i.Id == id)
                .SingleOrDefault();


            return inventory;

        }



        override public IList<Inventory> GetList()
        {
            return Context.Inventories
                .AsNoTracking()
                .OrderBy(i => i.Id)
                .ToList();
        }


    }
}