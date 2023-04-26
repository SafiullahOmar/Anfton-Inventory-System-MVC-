using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Anfton.Utilites.RequestCls
{
    public class RequestCls
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }

    }
    public class RequestParam {
        public int PageNo { get; set; }
        public int PageLength { get; set; }
        public string Search { get; set; }

    }
}