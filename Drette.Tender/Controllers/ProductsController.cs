using Drette.Tender.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var products = _productsRepository.GetList();

            return View(products);
        }
    }
}