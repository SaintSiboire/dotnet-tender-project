using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Data
{
    public class Repository
    {
        private Context _context = null;

        public Repository(Context context)
        {
            _context = context;
        }

        public IList<Part> GetParts()
        {
            return _context.Parts.OrderBy(p => p.Name).ToList();
        }

        public IList<Shop> GetShops()
        {
            return _context.Shops.OrderBy(s => s.Name).ToList();
        }

        public IList<Project> GetProjects()
        {
            return _context.Projects.OrderBy(p => p.Name).ToList();
        }
    }
}
