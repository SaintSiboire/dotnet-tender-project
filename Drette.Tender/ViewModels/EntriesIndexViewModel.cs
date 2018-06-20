using System.Collections.Generic;
using Drette.Tender.Shared.Models;

namespace Drette.Tender.ViewModels
{
    public class EntriesIndexViewModel
    {
        public IList<Entry> Entries { get; set; }
        public decimal TotalValue { get; set; }
        public decimal AverageInventoryValue { get; set; }
    }
}