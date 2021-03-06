﻿using Drette.Tender.Shared.Data;
using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drette.Tender.ViewModels
{
    public class InventoriesBaseViewModel
    {
        public Product Product { get; set; } = new Product();

        public Inventory Inventory { get; set; } = new Inventory();

        public InventoryInput InventoryInput { get; set; } = new InventoryInput();

        public SelectList ProductsSelectListItems { get; set; }

        public SelectList InventoriesSelectListItems { get; set; }

        public SelectList UnitsSelectListItems { get; set; }

        public List<Product> Products { get; set; }


        public InventoriesBaseViewModel()
        {
            InventoryInput.Date = DateTime.Now;
        }



        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public void Init(ProductsRepository productsRepository
)
        {
            ProductsSelectListItems = new SelectList(
                productsRepository.GetAll(),
                "ProductCode", "ProductCode");

        }
    }
}