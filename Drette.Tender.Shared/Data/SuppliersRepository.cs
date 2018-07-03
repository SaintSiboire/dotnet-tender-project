using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Data
{
    public class SuppliersRepository : BaseRepository<Supplier>
    {
        public SuppliersRepository(Context context) 
            : base(context)
        {}

        public override Supplier Get(int id, string userId, bool includeRelatedEntities = true)
        {
            throw new NotImplementedException();
        }

        public IList<Supplier> GetList()
        {
            return Context.Suppliers
                .OrderBy(s => s.Name)
                .ToList();
        }

        public override IList<Supplier> GetList(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
