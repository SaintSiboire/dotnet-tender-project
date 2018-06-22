using Drette.Tender.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drette.Tender.Controllers
{
    public class InventoriesController : BaseController
    {
        private InventoriesRepository _inventoriesRepository = null;

        public InventoriesController()
        {
            _inventoriesRepository = new InventoriesRepository(Context);
        }

        public ActionResult Index()
        {
            var inventories = _inventoriesRepository.GetList();

            return View(inventories);
        }
    }
}