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

        #region category
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
                    if (obj.Id > 0)
                    {
                        Category resp = (from x in db.Categories where x.Id == obj.Id select x).FirstOrDefault();
                        if (resp != null)
                        {
                            resp.Name = obj.Name;
                            resp.active = obj.Active;
                            result.message = "Data updated Succesfully";
                        }
                    }
                    else {

                        Category category = new Category();
                        category.Name = obj.Name;
                        category.active = obj.Active;
                        db.Categories.Add(category);
                        

                    }

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
        public ResponseCls RemoveCategory(RequestCls obj)
        {
            ResponseCls result = new ResponseCls();
            

            try
            {

                using (var db = dbEntity)
                {
                    if (obj.Id > 0)
                    {
                        Category resp = (from x in db.Categories where x.Id == obj.Id select x).FirstOrDefault();
                        db.Categories.Remove(resp);
                        db.SaveChanges();
                        result.message = "Data removed Successfully";
                        result.status = "Succes";
                        result.flag = 1;
                    }
                 

                    




                }
            }
            catch (Exception ex)
            {
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
                    if (!string.IsNullOrEmpty(obj.Search))
                    {
                        result.TotalRecords = (from x in db.Categories where x.Name.Contains(obj.Search) select x).Count();
                        result.data = (from x in db.Categories where x.Name.Contains(obj.Search) orderby x.Id descending select x)
                            .Skip((obj.PageNo == 0 ? 0 : obj.PageNo - 1) * obj.PageLength)
                            .Take(obj.PageLength)
                            .ToList();
                    }
                    else {
                        result.TotalRecords= (from x in db.Categories  select x).Count();
                        result.data = (from x in db.Categories  orderby x.Id descending select x)
                            .ToList();
                    }
                }
            }
            catch (Exception ex) {
                result.message = ex.Message.ToString();

            }

            return result;
        }
        #endregion

        #region Item
        public ResponseCls AddItem(RequestCls obj)
        {
            ResponseCls result = new ResponseCls();
            result.message = "Data Saved Successfully";
            result.status = "Succes";
            result.flag = 1;

            try
            {

                using (var db = dbEntity)
                {
                    if (obj.Id > 0)
                    {
                        Item resp = (from x in db.Items where x.Id == obj.Id select x).FirstOrDefault();
                        if (resp != null)
                        {
                            resp.Name = obj.Name;
                            resp.active = obj.Active;
                            result.message = "Data updated Succesfully";
                        }
                    }
                    else
                    {

                        Item item = new Item();
                        item.Name = obj.Name;
                        item.active = obj.Active;
                        db.Items.Add(item);


                    }

                    db.SaveChanges();




                }
            }
            catch (Exception ex)
            {
                result.message = ex.InnerException.Message.ToString();
                result.status = "Error";
                result.flag = 0;
            }

            return result;
        }

        public ResponseCls RemoveItem(RequestCls obj)
        {
            ResponseCls result = new ResponseCls();


            try
            {

                using (var db = dbEntity)
                {
                    if (obj.Id > 0)
                    {
                        Item resp = (from x in db.Items where x.Id == obj.Id select x).FirstOrDefault();
                        db.Items.Remove(resp);
                        db.SaveChanges();
                        result.message = "Data removed Successfully";
                        result.status = "Succes";
                        result.flag = 1;
                    }







                }
            }
            catch (Exception ex)
            {
                result.message = ex.InnerException.Message.ToString();
                result.status = "Error";
                result.flag = 0;
            }

            return result;
        }

        public ItemRespCls GetItem(RequestParam obj)
        {
            ItemRespCls result = new ItemRespCls();
            result.message = "Success";
            result.TotalRecords = 0;
            result.data = null;


            try
            {

                using (var db = new Inventory_AnftonEntities())
                {
                    if (!string.IsNullOrEmpty(obj.Search))
                    {
                        result.TotalRecords = (from x in db.Items where x.Name.Contains(obj.Search) select x).Count();
                        result.data = (from x in db.Items where x.Name.Contains(obj.Search) orderby x.Id descending select x)
                            .Skip((obj.PageNo == 0 ? 0 : obj.PageNo - 1) * obj.PageLength)
                            .Take(obj.PageLength)
                            .ToList();
                    }
                    else
                    {
                        result.TotalRecords = (from x in db.Items select x).Count();
                        result.data = (from x in db.Items orderby x.Id descending select x)
                            .ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                result.message = ex.Message.ToString();

            }

            return result;
        }

        #endregion
    }
}