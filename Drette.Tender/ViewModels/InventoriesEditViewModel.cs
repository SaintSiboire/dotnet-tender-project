using Drette.Tender.Shared.Models;
using Drette.Tender.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drette.Tender.ViewModels
{
    public class InventoriesEditViewModel : InventoryInputsViewModel
    {
        //public ProductModification ProductModification { get; set; } = new ProductModification();

        public SelectList UnitsSelectListItems { get; set; }

        public InventoriesEditViewModel()
        {
            //ProductModification.ModificationDate = DateTime.Now;
        }

        public int Id
        {
            get { return Inventory.Id; }
            set { Inventory.Id = value; }
        }


        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public void Init(InventoriesRepository inventoriesRepository,
                         UnitsRepository unitsRepository)
        {
            InventoriesSelectListItems = new SelectList(
                inventoriesRepository.GetAll(),
                "ProductCode", "ProductCode");

            UnitsSelectListItems = new SelectList(
                unitsRepository.GetList(), "Id", "Name");

        }

    }
}