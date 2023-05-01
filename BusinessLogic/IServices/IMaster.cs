using Inventory_Anfton.Utilites.RequestCls;
using Inventory_Anfton.Utilites.ResponseCls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Anfton.BusinessLogic.IServices
{
    public interface IMaster
    {

        #region category

        ResponseCls AddCategory(RequestCls obj);
        ResponseCls RemoveCategory(RequestCls obj);
        CategoryRespCls GetCategory(RequestParam obj);
        #endregion

        #region item

        ResponseCls AddItem(RequestCls obj);
        ResponseCls RemoveItem(RequestCls obj);
        ItemRespCls GetItem(RequestParam obj);
        #endregion

        #region warehouse  

        ResponseCls AddWarehouse(RequestCls obj);
        ResponseCls RemoveWarehouse(RequestCls obj);
        WarehouseRespCls GetWarehouse(RequestParam obj);
        #endregion

        #region Attribute  

        ResponseCls AddAttribute(RequestCls obj);
        ResponseCls RemoveAttribute(RequestCls obj);
        AttributeRespCls GetAtttribute(RequestParam obj);
        #endregion
    }
}
}