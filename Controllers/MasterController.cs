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
        [HttpPost]
        public JsonResult GetCategory()
        {
            RequestParam obj = new RequestParam();
            var start = Convert.ToInt32 (Request["start"]);
            var length = Convert.ToInt16(Request["length"]);
            var searchValue = Convert.ToString(Request["search[value]"]);

            start = start == 0 ? 0 : start / 10;
            obj.PageNo = start;
            obj.PageLength = length;
            obj.Search = searchValue;

            var result = _master.GetCategory(obj);
            return Json(new { data=result.data,recordFiltered=result.TotalRecords,recordTotal=result.TotalRecords,draw=Request["draw"]}, JsonRequestBehavior.AllowGet);
        }
    }
}