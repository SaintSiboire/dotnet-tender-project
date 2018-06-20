using System;
using System.Collections.Generic;
using System.Linq;
using Drette.Tender.Shared.Models;

namespace Drette.Tender.Shared.Data
{
    /// <summary>
    /// Repository for activities.
    /// </summary>
    public class ActivitiesRepository : BaseRepository<Item>
    {
        public ActivitiesRepository(Context context) 
            : base(context)
        {
        }


        /// <summary>
        /// Returns a collection of activities.
        /// </summary>
        /// <returns>A list of activities.</returns>
        public IList<Item> GetList()
        {
            return Context.Activities
                .OrderBy(a => a.Name)
                .ToList();
        }
    }
}