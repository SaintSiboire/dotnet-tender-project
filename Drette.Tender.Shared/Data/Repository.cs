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

        public IList<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.Name).ToList();
        }

        public IList<Supplier> GetShops()
        {
            return _context.Suppliers.OrderBy(s => s.Name).ToList();
        }


    }
}
