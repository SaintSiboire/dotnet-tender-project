using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Models
{
    public class InventoryDetails
    {

        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int PartId { get; set; }
        public int ShopId { get; set; }

        public Inventory Inventory { get; set; }
        public Part Part { get; set; }
        public Shop Shop { get; set; }

    }
}
