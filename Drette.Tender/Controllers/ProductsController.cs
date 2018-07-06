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


        public ProductsController(ProductsRepository productsRepository,
            InventoriesRepository inventoriesRepository,
            SuppliersRepository suppliersRepository,
            ProductTypesRepository productTypesRepository,
            UnitsRepository unitsRepository,
            InventoryInputsRepository inventoryInputsRepository)
        {
            _productsRepository = productsRepository;
            _inventoriesRepository = inventoriesRepository;
            _productTypesRepository = productTypesRepository;
            _suppliersRepository = suppliersRepository;
            _unitsRepository = unitsRepository;
            _inventoryInputsRepository = inventoryInputsRepository;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            IList<Product> products = _productsRepository.GetList(userId);

            int totalProduct = products
                .Count();

            decimal totalValue = products
                .Sum(p => p.Cost);

            var viewModel = new ProductsIndexViewModel()
            {
                Products = products,
                TotalProduct = totalProduct,
                TotalValue = totalValue
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

            Product product = _productsRepository.Get((int)id, userId, includeRelatedEntities : true);

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
                product.UserId = User.Identity.GetUserId();
                inventory.UserId = User.Identity.GetUserId();

                _inventoriesRepository.Add(inventory);
                var inventoryId = _inventoriesRepository.GetLast(inventory.UserId, includeRelatedEntoties: true).Id;

                product.InventoryId = inventoryId;

                _productsRepository.Add(product);


                TempData["Message"] = "Votre produit a été ajouté a la liste.";

                return RedirectToAction("Index");
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