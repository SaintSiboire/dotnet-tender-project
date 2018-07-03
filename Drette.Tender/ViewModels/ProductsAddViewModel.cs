using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Drette.Tender.Shared.Data;

namespace Drette.Tender.ViewModels
{
    public class ProductsAddViewModel : ProductsBaseViewModel
    {

        public int ProductTypeId { get; set; }
        public int SupplierId { get; set; }



    }
    
}