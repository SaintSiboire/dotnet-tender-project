using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Drette.Tender.Shared.Data;
using Drette.Tender.Shared.Models;
using Drette.Tender.ViewModels;

namespace Drette.Tender.Controllers
{
    public class EntriesController : Controller
    {
        private EntriesRepository _entriesRepository = null;
        private ItemsRepository _itemsRepository = null;

        public EntriesController(EntriesRepository entriesRepository, ItemsRepository itemsRepository)
        {
            _entriesRepository = entriesRepository;
            _itemsRepository = itemsRepository;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            IList<Entry> entries = _entriesRepository.GetList(userId);

            // Calculate the total value of the inventory.
            decimal totalValue = entries
                .Sum(e => e.Price);

            // Determine the number of Item in the inventory.
            int numberOfItems = entries
                .Select(e => e.Item)
                .Count();

            var viewModel = new EntriesIndexViewModel()
            {
                Entries = entries,
                TotalValue = totalValue,
                AverageInventoryValue = numberOfItems != 0 ?
                    (totalValue / numberOfItems) : 0
            };

            return View(viewModel);
        }

        public ActionResult Add()
        {
            var viewModel = new EntriesAddViewModel();

            viewModel.Entry.UserId = User.Identity.GetUserId();

            viewModel.Init(_itemsRepository);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(EntriesAddViewModel viewModel)
        {
            ValidateEntry(viewModel.Entry);

            if (ModelState.IsValid)
            {
                var entry = viewModel.Entry;
                entry.UserId = User.Identity.GetUserId();

                _entriesRepository.Add(viewModel.Entry);

                TempData["Message"] = "Your entry was successfully added!";

                return RedirectToAction("Index");
            }

            viewModel.Init(_itemsRepository);

            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId();

            Entry entry = _entriesRepository.Get((int)id, userId);

            if (entry == null)
            {
                return HttpNotFound();
            }

            var viewModel = new EntriesEditViewModel()
            {
                Entry = entry
            };
            viewModel.Init(_itemsRepository);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EntriesEditViewModel viewModel)
        {
            ValidateEntry(viewModel.Entry);

            if (ModelState.IsValid)
            {
                var entry = viewModel.Entry;
                var userId = User.Identity.GetUserId();

                if (!_entriesRepository.EntryOwnedByUserId(entry.Id, userId))
                {
                    return HttpNotFound();
                }

                entry.UserId = userId;

                _entriesRepository.Update(viewModel.Entry);

                TempData["Message"] = "Your entry was successfully updated!";

                return RedirectToAction("Index");
            }

            viewModel.Init(_itemsRepository);

            return View(viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId();

            Entry entry = _entriesRepository.Get((int)id, userId);

            if (entry == null)
            {
                return HttpNotFound();
            }

            return View(entry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();

            if (!_entriesRepository.EntryOwnedByUserId(id, userId))
            {
                return HttpNotFound();
            }

            _entriesRepository.Delete(id);

            TempData["Message"] = "Your entry was successfully deleted!";

            return RedirectToAction("Index");
        }

        private void ValidateEntry(Entry entry)
        {
            // If there aren't any "Price" field validation errors
            // then make sure that the price is greater than "0".
            if (ModelState.IsValidField("Price") && entry.Price <= 0)
            {
                ModelState.AddModelError("Price",
                    "The Price field value must be greater than '0'.");
            }
        }
    }
}