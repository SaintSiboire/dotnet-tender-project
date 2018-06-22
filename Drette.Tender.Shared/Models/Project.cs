using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Models
{
    public class Project
    {
        public Project()
        {
            Inventories = new List<Inventory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Inventory> Inventories { get; set; }
    }
}
