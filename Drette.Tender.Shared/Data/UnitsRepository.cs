using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Data
{
    public class UnitsRepository : BaseRepository<Unit>
    {
        public UnitsRepository(Context context)
            :base(context)
        {}

        public override Unit Get(int id, string userId, bool includeRelatedEntities = true)
        {
            throw new NotImplementedException();
        }

        public IList<Unit> GetList()
        {
            return Context.Units
                .OrderBy(u => u.Id)
                .ToList();
        }

        public override IList<Unit> GetList(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
