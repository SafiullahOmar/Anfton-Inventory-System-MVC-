using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Anfton.Models
{
    public class productDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string Item { get; set; }
        public string Category { get; set; }
        public string warhouse { get; set; }
        public Nullable<int> Availibility { get; set; }
    }
}