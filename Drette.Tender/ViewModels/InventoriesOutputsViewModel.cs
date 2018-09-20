using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drette.Tender.ViewModels
{
    public class InventoriesOutputsViewModel : InventoriesBaseViewModel
    {
        public InventoryOutput InventoryOutput { get; set; } = new InventoryOutput();

        public InventoriesOutputsViewModel()
        {
            InventoryOutput.Date = DateTime.Now;
        }
    }
}