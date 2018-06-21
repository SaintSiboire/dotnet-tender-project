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


        /// <summary>
        /// Returns a collection of items.
        /// </summary>
        /// <returns>A list of items.</returns>
        public IList<Inventory> GetList()
        {
            return Context.Items
                .OrderBy(a => a.Id)
                .ToList();
        }
    }
}