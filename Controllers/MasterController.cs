using Inventory_Anfton.BusinessLogic.IServices;
using Inventory_Anfton.BusinessLogic.ServiceCls;
using Inventory_Anfton.Utilites.RequestCls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Anfton.Controllers
{
    public class MasterController : Controller
    {
        IMaster _master;
        public MasterController()
        {
            _master = new MasterCls();
        }
        // GET: Master
        public ActionResult Category()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddCategory(RequestCls obj) {
            var result=_master.AddCategory(obj);

            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}