using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drette.Tender.ViewModels
{
    public class InventoryOutputsViewModel : InventoryInputsViewModel
    {
        public InventoryOutput InventoryOutput { get; set; } = new InventoryOutput();

        public InventoryOutputsViewModel()
        {
            InventoryOutput.Date = DateTime.Now;
        }
    }
}