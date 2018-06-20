using System.Collections.Generic;
using Drette.Tender.Shared.Models;

namespace Drette.Tender.ViewModels
{
    public class EntriesIndexViewModel
    {
        public IList<Entry> Entries { get; set; }
        public decimal TotalActivity { get; set; }
        public decimal AverageDailyActivity { get; set; }
    }
}