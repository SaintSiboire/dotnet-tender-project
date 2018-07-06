using Drette.Tender.Shared.Data;
using Drette.Tender.Shared.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Drette.Tender.ViewModels;

namespace Drette.Tender.Controllers
{
    public class InventoriesController : Controller
    {
        private InventoriesRepository _inventoriesRepository = null;

        private InventoryInputsRepository _inventoryInputsRepository = null;

        private ProductsRepository _productsRepository = null;

        public InventoriesController(InventoriesRepository inventoriesRepository, InventoryInputsRepository inventoryInputsRepository,
                                        ProductsRepository productsRepository)
        {
            _inventoriesRepository = inventoriesRepository;
            _inventoryInputsRepository = inventoryInputsRepository;
            _productsRepository = productsRepository;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            IList<Inventory> inventories = _inventoriesRepository.GetList(userId);

            return View(inventories);
        }

        public ActionResult Input()
        {
            var viewModel = new InventoryInputsViewModel();

            viewModel.InventoryInput.UserId = User.Identity.GetUserId();

            viewModel.Init(_productsRepository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Input(InventoryInputsViewModel viewModel)
        {
            // ValidateProduct(viewModel.Product);

            if (ModelState.IsValid)
            {
                var input = viewModel.InventoryInput;
                var productCode = viewModel.Product.ProductCode;
                var product = _productsRepository.GetByProductCode(productCode);
                var inventoryId = product.Inventory.Id;

                var inventory = _inventoriesRepository.GetById(inventoryId);
                inventory.TotalCost += input.Cost;
                inventory.UnitQty += input.Quantity;
                inventory.AverageCost = inventory.TotalCost / inventory.UnitQty;

                input.InventoryId = inventoryId;
                input.UserId = User.Identity.GetUserId();

                _inventoryInputsRepository.Add(input);

                IList<InventoryInput> inventoryInputs = _inventoryInputsRepository.GetListByInventory(inventoryId);







                TempData["Message"] = "Votre entrée a été ajouté a l'inventaire.";

                return RedirectToAction("Index");
            }

            viewModel.Init(_productsRepository);

            return View(viewModel);
        }

    }
}