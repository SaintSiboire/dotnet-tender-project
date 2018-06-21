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
    public class Part
    {
        public Part()
        {
            Inventories = new List<Inventory>();
        }

        public int Id { get; set; }
        public string Code { get; set; }

        public ICollection<Inventory> Inventories { get; set; }

    }
}
