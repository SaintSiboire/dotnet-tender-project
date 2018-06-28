using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drette.Tender.ViewModels
{
    public class ProductsIndexViewModel
    {
        public IList<Product> Products { get; set; }
        public int TotalProduct { get; set; }
        public decimal TotalValue { get; set; }
    }
}