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


        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }


        public int ProductTypeId { get; set; }

        public int InventoryId { get; set; }

        public int SupplierId { get; set; }
        public string SupplierProductCode { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
        public ProductType ProductType { get; set; }
        public Inventory Inventory { get; set; }
        public Supplier Supplier { get; set; }



    }
}
