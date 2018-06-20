using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Models
{
    /// <summary>
    /// The Model Code and Name of Items.
    /// </summary>
    public class Model
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int SpecId { get; set; }
    }
}
