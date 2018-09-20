using Drette.Tender.Shared.Data;
using Drette.Tender.Shared.Models;
using Drette.Tender.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Drette.Tender.Controllers
{
    public class SuppliersController : Controller
    {
        private SuppliersRepository _suppliersRepository = null;

        public SuppliersController(SuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public ActionResult Index()
        {
            IList<Supplier> suppliers = _suppliersRepository.GetList();

            int totalSuppliers = suppliers.Count();

            var viewModel = new SuppliersBaseViewModel()
            {
                Suppliers = suppliers,
                TotalSuppliers = totalSuppliers
            };

            return View(viewModel);
        }

        public ActionResult Add()
        {
            var viewmodel = new SuppliersBaseViewModel();

            viewmodel.Init(_suppliersRepository);

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Add(SuppliersBaseViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var supplier = viewModel.Supplier;

                _suppliersRepository.Add(supplier);

                TempData["Message"] = "Le fournisseur a été ajouté a la liste.";

                return RedirectToAction("Index");
            }

            viewModel.Init(_suppliersRepository);

            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var supplier = _suppliersRepository.GetById((int)id);


            if (supplier == null)
            {
                return HttpNotFound();
            }

            var viewModel = new SuppliersBaseViewModel()
            {
                Supplier = supplier
            };

            viewModel.Init(_suppliersRepository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(SuppliersBaseViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var supplier = viewModel.Supplier;

                _suppliersRepository.Update(supplier);

                TempData["Message"] = "Le fournisseur a été modifié correctement.";

                return RedirectToAction("Index");
            }

            viewModel.Init(_suppliersRepository);

            return View(viewModel);
        }


    }
}