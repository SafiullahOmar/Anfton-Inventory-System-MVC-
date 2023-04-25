using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Anfton.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Category()
        {
            return View();
        }
    }
}