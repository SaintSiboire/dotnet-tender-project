using Drette.Tender.Shared.Data;
using Drette.Tender.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drette.Tender.ViewModels
{
    public class UnitsBaseViewModel
    {
        public Unit Unit { get; set; } = new Unit();

        public IList<Unit> Units { get; set; }

        public SelectList UnitsSelectListItems { get; set; }


        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public void Init(UnitsRepository unitsRepository)
        {
            UnitsSelectListItems = new SelectList(
               unitsRepository.GetList(),
               "Id", "Name", "Quantity");

        }
    }
}