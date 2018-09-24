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
    public class UnitsController : Controller
    {
        private UnitsRepository _unitsRepository = null;

        public UnitsController(UnitsRepository unitsRepository)
        {
            _unitsRepository = unitsRepository;
        }

        public ActionResult Index()
        {
            IList<Unit> units = _unitsRepository.GetList();

            var viewModel = new UnitsBaseViewModel()
            {
                Units = units
            };

            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Unit unit = _unitsRepository.GetUnit((int)id);

            if(unit == null)
            {
                return HttpNotFound();
            }

            var viewModel = new UnitsBaseViewModel()
            {
                Unit = unit
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(UnitsBaseViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var unit = viewModel.Unit;

                _unitsRepository.Update(unit);

                TempData["Message"] = "L'unité a été modifié correctement.";

                return RedirectToAction("Index", "Inventories");
            }

            viewModel.Init(_unitsRepository);

            return View(viewModel);
        }

        public ActionResult Add()
        {
            var viewModel = new UnitsBaseViewModel();

            viewModel.Init(_unitsRepository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(UnitsBaseViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var unit = viewModel.Unit;

                _unitsRepository.Add(unit);

                TempData["Message"] = "L'unité a été ajouté correctement.";

                return RedirectToAction("Index", "Inventories");
            }

            viewModel.Init(_unitsRepository);

            return View(viewModel);
        }

    }
}