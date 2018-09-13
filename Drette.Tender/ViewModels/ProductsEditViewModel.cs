using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drette.Tender.ViewModels
{
    public class ProductsEditViewModel : ProductsBaseViewModel
    {
        public ProductModification ProductModification { get; set; } = new ProductModification();

        public ProductsEditViewModel()
        {
            ProductModification.ModificationDate = DateTime.Now;
        }

        public int Id
        {
            get { return Product.Id; }
            set { Product.Id = value; }
        }

        public int InventoryId
        {
            get { return Product.InventoryId; }
            set { Product.InventoryId = value; }
        }
    }
}