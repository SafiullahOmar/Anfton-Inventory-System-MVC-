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
}