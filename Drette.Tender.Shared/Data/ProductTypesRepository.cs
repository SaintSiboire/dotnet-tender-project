using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Data
{
    public class ProductTypesRepository : BaseRepository<ProductType>
    {
        public ProductTypesRepository(Context context)
            :base(context)
        {}

        public override ProductType Get(int id, string userId, bool includeRelatedEntities = true)
        {
            throw new NotImplementedException();
        }

        public IList<ProductType> GetList()
        {
            return Context.ProductTypes
                .OrderBy(p => p.Name)
                .ToList();
        }

        public override IList<ProductType> GetList(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
