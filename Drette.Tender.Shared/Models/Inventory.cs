using System.Collections.Generic;

namespace Drette.Tender.Shared.Models
{
    /// <summary>
    /// Represents the inventory of a product.
    /// </summary>
    public class Inventory
    {


        public int Id { get; set; }
        public bool Counted { get; set; }
        public bool Followed { get; set; }
        public int UnitQty { get; set; }
        public int UnitQtyByLot { get; set; }
        public int UnitMinQty { get; set; }
        public int UnitMaxQty { get; set; }
        public int OrderMinQty { get; set; }
        public string Location { get; set; }
        public string LocationPrecision { get; set; }
        public string Notes { get; set; }

        public int UnitId { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public Unit Unit { get; set; }




    }
}