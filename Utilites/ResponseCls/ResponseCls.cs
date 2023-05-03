using Inventory_Anfton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Anfton.Utilites.ResponseCls
{
    public class ResponseCls
    {
        public string message { get; set; }
        public string status { get; set; }
        public int flag { get; set; }

    }

    public class CategoryRespCls {
        public string message { get; set; }
        public int TotalRecords { get; set; }
        public List<Category> data { get; set; }
    }

    public class ItemRespCls
    {
        public string message { get; set; }
        public int TotalRecords { get; set; }
        public List<Item> data { get; set; }
    }

    public class WarehouseRespCls
    {
        public string message { get; set; }
        public int TotalRecords { get; set; }
        public List<Warehouse> data { get; set; }
    }

    public class AttributeRespCls
    {
        public string message { get; set; }
        public int TotalRecords { get; set; }
        public List<Attribute> data { get; set; }
    }
    public class ProductRespCls
    {
        public string message { get; set; }
        public int TotalRecords { get; set; }
        public List<productDTO> data { get; set; }
    }

    public class ddlResponse {
        public string Message { get; set; }
        public string status { get; set; }
        public List<DropDownDTO> data { get; set; }
    }
}