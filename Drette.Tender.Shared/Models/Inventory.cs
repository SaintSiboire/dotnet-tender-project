using System.Collections.Generic;

namespace Drette.Tender.Shared.Models
{
    /// <summary>
    /// Represents a part in the inventory.
    /// </summary>
    public class Inventory
    {


        public int Id { get; set; }
        public int PartId { get; set; }
        public int ShopId { get; set; }
        public decimal Price { get; set; }

        public Part Part { get; set; }
        public Shop Shop { get; set; }


    }
}