using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Drette.Tender.Shared.Data;
using Drette.Tender.Shared.Models;

namespace Drette.Tender.ViewModels
{
    public class EntriesAddViewModel
        : EntriesBaseViewModel
    {
        public EntriesAddViewModel()
        {
            Entry.Date = DateTime.Today;
        }
    }
}