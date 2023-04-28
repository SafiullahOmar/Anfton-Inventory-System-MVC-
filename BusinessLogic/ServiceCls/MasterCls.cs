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
                result.message = ex.InnerException.Message.ToString();
                result.status = "Error";
                result.flag = 0;
            }

                return result;
           
        }

        public CategoryRespCls GetCategory(RequestParam obj)
        {
            CategoryRespCls result = new CategoryRespCls();
            result.message = "Success";
            result.TotalRecords = 0;
            result.data = null;

            try
            {

                using (var db = new Inventory_AnftonEntities()) {
                    if (string.IsNullOrEmpty(obj.Search))
                    {
                        result.TotalRecords = (from x in db.Categories where x.Name.Contains(obj.Search) select x).Count();
                        result.data = (from x in db.Categories where x.Name.Contains(obj.Search) orderby x.Id descending select x)
                            .Skip((obj.PageNo == 0 ? 0 : obj.PageNo - 1) * obj.PageLength)
                            .Take(obj.PageLength)
                            .ToList();
                    }
                    else {
                        result.TotalRecords = (from x in db.Categories   select x).Count();
                        result.data = (from x in db.Categories  orderby x.Id descending select x)
                            .Skip((obj.PageNo==0?0:obj.PageNo-1) * obj.PageLength)
                            .Take(obj.PageLength)
                            .ToList();
                    }
                }
            }
            catch (Exception ex) {
                result.message = ex.Message.ToString();

            }

            return result;
        }
    }
}