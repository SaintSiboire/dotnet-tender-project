using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Models
{
    /// <summary>
    /// The Detail of the Item.
    /// </summary>
    public class Product
    {
        public Product()
        {
            Inventories = new List<Inventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int InventoryId { get; set; }

        public int SupplierId { get; set; }
        public string SupplierProductCode { get; set; }

        public Inventory Inventory { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<Inventory> Inventories { get; set; }

    }
}
