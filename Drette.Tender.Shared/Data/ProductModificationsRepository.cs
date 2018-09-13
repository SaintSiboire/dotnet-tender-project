using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Data
{
    public class ProductModificationsRepository : BaseRepository<ProductModification>
    {
        public ProductModificationsRepository(Context context)
            :base(context)
        {}

        public override ProductModification Get(int id, string userId, bool includeRelatedEntities = true)
        {
            throw new NotImplementedException();
        }

        public override IList<ProductModification> GetList(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
