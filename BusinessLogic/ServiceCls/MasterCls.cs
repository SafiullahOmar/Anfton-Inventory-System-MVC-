using Inventory_Anfton.BusinessLogic.IServices;
using Inventory_Anfton.Utilites.RequestCls;
using Inventory_Anfton.Utilites.ResponseCls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Anfton.BusinessLogic.ServiceCls
{
    public class MasterCls : IMaster
    {
        Inventory_AnftonEntities dbEntity;
        public MasterCls()
        {
            dbEntity = new Inventory_AnftonEntities();
        }
        public ResponseCls AddCategory(RequestCls obj)
        {
            ResponseCls result = new ResponseCls();
            result.message = "Data Saved Successfully";
            result.status = "Succes";
            result.flag = 1;

            try
            {
                using (var db = dbEntity)
                {
                    Category category = new Category();
                    category.Name = obj.Name;
                    category.active = obj.Active;
                    db.Categories.Add(category);
                    db.SaveChanges();

                }
            }
            catch (Exception ex) {
                result.message = ex.Message.ToString();
                result.status = "Error";
                result.flag = 0;
            }

                return result;
           
        }
    }
}