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
        public JsonResult RemoveCategory(RequestCls obj)
        {
            var result = _master.RemoveCategory(obj);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCategory()
          {
            RequestParam obj = new RequestParam();

            //  var draw = Request.Form.GetValues("draw").FirstOrDefault();
            //var start = Request.Form.GetValues("start").FirstOrDefault();
            //var length = Request.Form.GetValues("length").FirstOrDefault();
            //var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            //var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            //var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

            ////Paging Size (10,20,50,100)    
            //int pageSize = length != null ? Convert.ToInt32(length) : 0;
            //int skip = start != null ? Convert.ToInt32(start) : 0;
            //int recordsTotal = 0;

            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var searchValue = Request["search[value]"];

            start = start == 0 ? 0 : start / 10;
            obj.PageNo = start;
            obj.PageLength = length;
            obj.Search = searchValue;
            var result = _master.GetCategory(obj);
            //Sorting
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //{
            //    result = result.OrderBy(sortColumn + " " + sortColumnDir);
            //}
            ////Search    
            //if (!string.IsNullOrEmpty(searchValue))
            //{
            //    result = result.Where(m => m.Name == searchValue);
            //}

            //total number of rows count     
         //   recordsTotal = result.Count();
            //Paging     
           // var data = result.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data    
            //return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            return Json(new {data=result.data,recordFiltered=result.TotalRecords,recordTotal=result.TotalRecords,draw=Request["draw"] }, JsonRequestBehavior.AllowGet);
        }
    }
}