//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventory_Anfton
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders_Item
    {
        public int Id { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
    }
}
