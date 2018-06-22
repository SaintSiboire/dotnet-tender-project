using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Data
{
    public class PartsRepository : BaseRepository<Part>
    {
        public PartsRepository(Context context)
            :base(context)
        {
        }

        public override Part Get(int id, bool includeRelatedEntities = true)
        {
            var part = Context.Parts.AsQueryable();

            if(includeRelatedEntities)
            {
                part = part
                    .Include(p => p.Inventories);
            }

            return part
                    .Where(p => p.Id == id)
                    .SingleOrDefault();
        }

        public override IList<Part> GetList()
        {
            return Context.Parts
                        .AsNoTracking()
                        .OrderBy(p => p.Code)
                        .ToList();
        }
    }
}
