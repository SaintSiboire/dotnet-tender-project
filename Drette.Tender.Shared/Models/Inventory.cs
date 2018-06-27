using System.Collections.Generic;

namespace Drette.Tender.Shared.Models
{
    /// <summary>
    /// Represents the inventory of a product.
    /// </summary>
    public class Inventory
    {


        public int Id { get; set; }
        public int ProductId { get; set; }
        public bool Count { get; set; }
        public bool Follow { get; set; }
        public int UnitTypeId { get; set; }
        public int UnitQty { get; set; }
        public int UnitQtyByLot { get; set; }
        public int UnitMinQty { get; set; }
        public int UnitMaxQty { get; set; }
        public int OrderMinQty { get; set; }
        public string Location { get; set; }
        public string LocationPrecision { get; set; }
        public string Notes { get; set; }


        public Unit Unit { get; set; }
        public Product Product { get; set; }


    }
}