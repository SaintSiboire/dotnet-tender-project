using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TaskInformationsId { get; set; }
        public TaskInformations TaskInformations { get; set; }
    }
}
