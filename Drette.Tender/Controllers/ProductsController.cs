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

namespace Drette.Tender.Controllers
{
    public class ProductsController : BaseController
    {
        private ProductsRepository _productsRepository = null;

        public ProductsController()
        {
            _productsRepository = new ProductsRepository(Context);
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
    }
}