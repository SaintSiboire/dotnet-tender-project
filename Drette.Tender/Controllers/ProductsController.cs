using Drette.Tender.Shared.Data;
using Drette.Tender.Shared.Models;
using Drette.Tender.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;

namespace Drette.Tender.Controllers
{
    public class ProductsController : Controller
    {
        private ProductsRepository _productsRepository = null;
        private InventoriesRepository _inventoriesRepository = null;
        private SuppliersRepository _suppliersRepository = null;
        private ProductTypesRepository _productTypesRepository = null;
        private UnitsRepository _unitsRepository = null;
        private InventoryInputsRepository _inventoryInputsRepository = null;
        private ProductModificationsRepository _productModificationsRepository = null;


        public ProductsController(ProductsRepository productsRepository,
            InventoriesRepository inventoriesRepository,
            SuppliersRepository suppliersRepository,
            ProductTypesRepository productTypesRepository,
            UnitsRepository unitsRepository,
            InventoryInputsRepository inventoryInputsRepository,
            ProductModificationsRepository productModificationsRepository)
        {
            _productsRepository = productsRepository;
            _inventoriesRepository = inventoriesRepository;
            _productTypesRepository = productTypesRepository;
            _suppliersRepository = suppliersRepository;
            _unitsRepository = unitsRepository;
            _inventoryInputsRepository = inventoryInputsRepository;
            _productModificationsRepository = productModificationsRepository;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            IList<Product> products = _productsRepository.GetAll();

            IList<Inventory> inventories = _inventoriesRepository.GetAll();

            int totalProduct = products
                .Count();




            

            var viewModel = new ProductsIndexViewModel()
            {
                Products = products,
                TotalProduct = totalProduct
            };

            return View(viewModel);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId();

            Product product = _productsRepository.GetById((int)id);

            if(product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        public ActionResult Add()
        {
            var viewModel = new ProductsAddViewModel();

            viewModel.Product.UserId = User.Identity.GetUserId();
            //viewModel.Product.User.UserName = User.Identity.GetUserName();
            viewModel.Inventory.UserId = User.Identity.GetUserId();
           // viewModel.Inventory.User.UserName = User.Identity.GetUserName();

            viewModel.Init(_productTypesRepository,  _suppliersRepository, _unitsRepository, User.Identity.GetUserId());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(ProductsAddViewModel viewModel)
        {
           // ValidateProduct(viewModel.Product);

            if(ModelState.IsValid)
            {
                var product = viewModel.Product;
                var inventory = viewModel.Inventory;


                _inventoriesRepository.Add(inventory);
                var inventoryId = _inventoriesRepository.GetLast( includeRelatedEntoties: true).Id;

                product.InventoryId = inventoryId;

                _productsRepository.Add(product);


                TempData["Message"] = "Votre produit a été ajouté a la liste.";

                return RedirectToAction("Index");
            }

            viewModel.Init(_productTypesRepository, _suppliersRepository, _unitsRepository, User.Identity.GetUserId());

            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId();

            var product = _productsRepository.GetById((int)id);


            if(product == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ProductsEditViewModel()
            {
                Product = product
            };

            viewModel.Init(_productTypesRepository, _suppliersRepository, _unitsRepository, User.Identity.GetUserId());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductsEditViewModel viewModel)
        {
            //ValidateProduct(viewModel.Product);

            if(ModelState.IsValid)
            {
                var product = viewModel.Product;
                var modification = viewModel.ProductModification;
                modification.ProductId = product.Id;
                modification.UserId = User.Identity.GetUserId();

                _productsRepository.Update(product);
                _productModificationsRepository.Add(modification);

                TempData["Message"] = "Votre produit a été modifié correctement.";

                return RedirectToAction("Detail", new { id = product.Id });
            }

            viewModel.Init(_productTypesRepository, _suppliersRepository, _unitsRepository, User.Identity.GetUserId());

            return View(viewModel);
        }

        private void ValidateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}