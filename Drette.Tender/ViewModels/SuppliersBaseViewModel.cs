using Drette.Tender.Shared.Data;
using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drette.Tender.ViewModels
{
    public class SuppliersBaseViewModel
    {
        public Supplier Supplier { get; set; }

        public IList<Supplier> Suppliers { get; set; }

        public SelectList SuppliersSelectListItems { get; set; }

        public int TotalSuppliers { get; set; }

        public void Init(SuppliersRepository suppliersRepository)
        {
            SuppliersSelectListItems = new SelectList(
                suppliersRepository.GetList(), "Name", "WebSite");
        }

    }
}