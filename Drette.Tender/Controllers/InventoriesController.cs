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

        private ProductModificationsRepository _productModificationsRepository = null;

        private UnitsRepository _unitsRepository = null;


        public InventoriesController(InventoriesRepository inventoriesRepository, InventoryInputsRepository inventoryInputsRepository,
                                        ProductsRepository productsRepository, InventoryOutputsRepository inventoryOutputsRepository, 
                                        ProductModificationsRepository productModificationsRepository, UnitsRepository unitsRepository)
        {
            _inventoriesRepository = inventoriesRepository;
            _inventoryInputsRepository = inventoryInputsRepository;
            _productsRepository = productsRepository;
            _inventoryOutputsRepository = inventoryOutputsRepository;
            _productModificationsRepository = productModificationsRepository;
            _unitsRepository = unitsRepository;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            IList<Inventory> inventories = _inventoriesRepository.GetAll();

            return View(inventories);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId();

            Inventory inventory = _inventoriesRepository.GetById((int)id);

            if (inventory == null)
            {
                return HttpNotFound();
            }

            return View(inventory);
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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId();

            var inventory = _inventoriesRepository.GetById((int)id);


            if (inventory == null)
            {
                return HttpNotFound();
            }

            var viewModel = new InventoriesEditViewModel()
            {
                Inventory = inventory
            };

            viewModel.Init(_inventoriesRepository, _unitsRepository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(InventoriesEditViewModel viewModel)
        {
            //ValidateProduct(viewModel.Product);

            if (ModelState.IsValid)
            {
                var inventory = viewModel.Inventory;
                //var modification = viewModel.ProductModification;
               // modification.InventoryId = inventory.Id;
                //modification.UserId = User.Identity.GetUserId();

                _inventoriesRepository.Update(inventory);
                //_productModificationsRepository.Add(modification);

                TempData["Message"] = "Votre produit a été modifié correctement.";

                return RedirectToAction("Detail", new { id = inventory.Id });
            }

            viewModel.Init(_inventoriesRepository, _unitsRepository);

            return View(viewModel);
        }


    }
}