using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drette.Tender.ViewModels
{
    public class InventoriesIndexViewModel
    {
        public IList<Inventory> Inventories { get; set; }
    }
}