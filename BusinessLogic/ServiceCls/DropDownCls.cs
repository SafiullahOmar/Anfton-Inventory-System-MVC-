using Inventory_Anfton.BusinessLogic.IServices;
using Inventory_Anfton.Models;
using Inventory_Anfton.Utilites.ResponseCls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Anfton.BusinessLogic.ServiceCls
{
    public class DropDownCls : IDropdown

    {
        Inventory_AnftonEntities db;
        public DropDownCls()
        {
            db = new Inventory_AnftonEntities();
        }

        public ddlResponse BindCategory()
        {
            ddlResponse result = new ddlResponse();
            result.data = null;
            result.Message = "success";
            result.status = "suceess";

            try
            {

                (from x in db.Categories select new DropDownDTO { code = x.Id, Text = x.Name }).ToList();
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.ToString();
                result.status = "error";
            }
            return result;
        }

        public ddlResponse BindItems()
        {
            ddlResponse result = new ddlResponse();
            result.data = null;
            result.Message = "success";
            result.status = "suceess";

            try {

                result.data=(from x in db.Items select new DropDownDTO { code = x.Id, Text = x.Name }).ToList();
            }
            catch (Exception ex) {
                result.Message =ex.Message.ToString();
                result.status = "error";
            }
            return result;
        }

        public ddlResponse BindWarehouse()
        {
            ddlResponse result = new ddlResponse();
            result.data = null;
            result.Message = "success";
            result.status = "suceess";

            try
            {

                (from x in db.Warehouses select new DropDownDTO { code = x.Id, Text = x.Name }).ToList();
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.ToString();
                result.status = "error";
            }
            return result;
        }
    }
}