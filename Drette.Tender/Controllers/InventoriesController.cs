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

        private InventoryOutputsRepository _inventoryOutputsRepository = null;

        private ProductsRepository _productsRepository = null;


        public InventoriesController(InventoriesRepository inventoriesRepository, InventoryInputsRepository inventoryInputsRepository,
                                        ProductsRepository productsRepository, InventoryOutputsRepository inventoryOutputsRepository)
        {
            _inventoriesRepository = inventoriesRepository;
            _inventoryInputsRepository = inventoryInputsRepository;
            _productsRepository = productsRepository;
            _inventoryOutputsRepository = inventoryOutputsRepository;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            IList<Inventory> inventories = _inventoriesRepository.GetAll();

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

        public ActionResult Output()
        {
            var viewModel = new InventoryOutputsViewModel();

            viewModel.InventoryOutput.UserId = User.Identity.GetUserId();

            viewModel.Init(_productsRepository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Output(InventoryOutputsViewModel viewModel)
        {
            // ValidateProduct(viewModel.Product);

            if (ModelState.IsValid)
            {
                var output = viewModel.InventoryOutput;
                var productCode = viewModel.Product.ProductCode;
                var product = _productsRepository.GetByProductCode(productCode);
                var inventoryId = product.Inventory.Id;

                var inventory = _inventoriesRepository.GetById(inventoryId);
                inventory.UnitQty -= output.Quantity;
                inventory.TotalCost -= output.Quantity * inventory.AverageCost;
                inventory.AverageCost = inventory.TotalCost / inventory.UnitQty;

                output.InventoryId = inventoryId;
                output.UserId = User.Identity.GetUserId();

                _inventoryOutputsRepository.Add(output);

                TempData["Message"] = "Votre entrée a été retiré de l'inventaire.";

                return RedirectToAction("Index");
            }

            viewModel.Init(_productsRepository);

            return View(viewModel);
        }

    }
}