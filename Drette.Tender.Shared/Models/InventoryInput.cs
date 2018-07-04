using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Models
{
    public class InventoryInput
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
