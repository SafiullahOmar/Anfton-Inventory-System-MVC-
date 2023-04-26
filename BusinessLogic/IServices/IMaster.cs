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
        ResponseCls AddCategory(RequestCls obj);
        CategoryRespCls GetCategory(RequestParam obj);
    }
}