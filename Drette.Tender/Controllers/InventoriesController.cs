using Drette.Tender.Shared.Data;
using Drette.Tender.Shared.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace Drette.Tender.Controllers
{
    public class InventoriesController : Controller 
    {
        private InventoriesRepository _inventoriesRepository = null;

        public InventoriesController(InventoriesRepository inventoriesRepository)
        {
            _inventoriesRepository = inventoriesRepository;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            IList<Inventory> inventories = _inventoriesRepository.GetList(userId);

            return View(inventories);
        }
    }
}