using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Drette.Tender.Shared.Data;
using Drette.Tender.Shared.Models;

namespace Drette.Tender.ViewModels
{
    public abstract class EntriesBaseViewModel
    {
        public Entry Entry { get; set; } = new Entry();

        public SelectList ItemsSelectList { get; set; }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public void Init(InventoriesRepository itemsRepository)
        {
            ItemsSelectList = new SelectList(
                itemsRepository.GetList(), "Id", "Name");
        }
    }
}