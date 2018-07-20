using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drette.Tender.ViewModels
{
    public class ProductsEditViewModel
        : ProductsBaseViewModel
    {
        public ProductsEditViewModel()
        {
            Product.ModificationDate = DateTime.Now;
        }

        public int Id
        {
            get { return Product.Id; }
            set { Product.Id = value; }
        }
    }
}