using Inventory_Anfton.Utilites.ResponseCls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Anfton.BusinessLogic.IServices
{
    public interface IDropdown
    {
        ddlResponse BindItems();
        ddlResponse BindCategory();
        ddlResponse BindWarehouse();
    }
}