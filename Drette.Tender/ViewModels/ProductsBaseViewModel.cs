using Drette.Tender.Shared.Data;
using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drette.Tender.ViewModels
{
    public class ProductsBaseViewModel
    {
        public Product Product { get; set; } = new Product();

        public Inventory Inventory { get; set; } = new Inventory();

        public SelectList ProductTypesSelectListItems { get; set; }

        public SelectList SuppliersSelectListItems { get; set; }

        public SelectList UnitsSelectListItems { get; set; }




        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public void Init(ProductTypesRepository productTypesRepository,
            SuppliersRepository suppliersRepository,
            UnitsRepository unitsRepository,           
            string userId)
        {
            ProductTypesSelectListItems = new SelectList(
                productTypesRepository.GetList(),
                "Id", "Name");
            SuppliersSelectListItems = new SelectList(
               suppliersRepository.GetList(),
               "Id", "Name");
            UnitsSelectListItems = new SelectList(
               unitsRepository.GetList(),
               "Id", "Name", "Quantity");

        }
    }
}