﻿using System;
using System.Collections.Generic;
using System.Linq;
using Drette.Tender.Shared.Models;
using System.Data.Entity;

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

        public override Inventory Get(int id,string userId, bool includeRelatedEntities = true)
        {
            var inventory = Context.Inventories.AsQueryable();

            if(includeRelatedEntities)
            {
                inventory = inventory
                        .Include(i => i.Unit);
               

            }
            return inventory
                        .Where(i => i.Id == id && i.UserId == userId)
                        .SingleOrDefault(); 
        }

        public Inventory GetLast( bool includeRelatedEntoties = true)
        {
            var inventory = Context.Inventories.AsQueryable();

            if(includeRelatedEntoties)
            {
                inventory = inventory
                    .Include(i => i.Unit);
            }

            return inventory
                .OrderByDescending(i => i.Id)
                .FirstOrDefault();
        }

        public Inventory GetById(int id)
        {
            var inventory = Context.Inventories.AsQueryable();


            return inventory
                .Include(i => i.Unit)
                .Where(i => i.Id == id)
                .SingleOrDefault();
        }


        public override IList<Inventory> GetList(string userId)
        {
            return Context.Inventories
                        .Include(i => i.Unit)
                        .Where(i => i.UserId == userId)
                        .OrderBy(i => i.Id)
                        .ToList();
        }

        public IList<Inventory> GetAll()
        {
            return Context.Inventories
                        .Include(i => i.Unit)
                        .OrderBy(i => i.Id)
                        .ToList();
        }

    }
}