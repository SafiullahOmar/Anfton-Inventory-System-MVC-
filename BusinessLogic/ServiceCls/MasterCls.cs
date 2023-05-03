using Inventory_Anfton.BusinessLogic.IServices;
using Inventory_Anfton.Models;
using Inventory_Anfton.Utilites.RequestCls;
using Inventory_Anfton.Utilites.ResponseCls;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
                            //db.Items.Attach(resp);
                            db.Entry(resp).State = System.Data.Entity.EntityState.Modified;
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
            //catch (Exception ex)
            //{

            //    result.message = ex.InnerException.Message.ToString();
            //    result.status = "Error";
            //    result.flag = 0;
            //}
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.message =validationError.PropertyName+validationError.ErrorMessage;
                    }
                }
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

        #region warehouse

        public ResponseCls AddWarehouse(RequestCls obj)
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
                        Warehouse resp = (from x in db.Warehouses where x.Id == obj.Id select x).FirstOrDefault();
                        if (resp != null)
                        {
                            resp.Name = obj.Name;
                            resp.Active = obj.Active;
                            //db.Items.Attach(resp);
                            db.Entry(resp).State = System.Data.Entity.EntityState.Modified;
                            result.message = "Data updated Succesfully";
                        }
                    }
                    else
                    {

                        Warehouse warehouse  = new Warehouse();
                        warehouse.Name = obj.Name;
                        warehouse.Active = obj.Active;
                        db.Warehouses.Add(warehouse);


                    }

                    db.SaveChanges();




                }
            }
            //catch (Exception ex)
            //{

            //    result.message = ex.InnerException.Message.ToString();
            //    result.status = "Error";
            //    result.flag = 0;
            //}
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.message = validationError.PropertyName + validationError.ErrorMessage;
                    }
                }
            }

            return result;
        }

        public ResponseCls RemoveWarehouse(RequestCls obj)
        {
            ResponseCls result = new ResponseCls();


            try
            {

                using (var db = dbEntity)
                {
                    if (obj.Id > 0)
                    {
                        Warehouse resp = (from x in db.Warehouses where x.Id == obj.Id select x).FirstOrDefault();
                        db.Warehouses.Remove(resp);
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

        public WarehouseRespCls GetWarehouse(RequestParam obj)
        {
            WarehouseRespCls result = new WarehouseRespCls();
            result.message = "Success";
            result.TotalRecords = 0;
            result.data = null;


            try
            {

                using (var db = new Inventory_AnftonEntities())
                {
                    if (!string.IsNullOrEmpty(obj.Search))
                    {
                        result.TotalRecords = (from x in db.Warehouses where x.Name.Contains(obj.Search) select x).Count();
                        result.data = (from x in db.Warehouses where x.Name.Contains(obj.Search) orderby x.Id descending select x)
                            .Skip((obj.PageNo == 0 ? 0 : obj.PageNo - 1) * obj.PageLength)
                            .Take(obj.PageLength)
                            .ToList();
                    }
                    else
                    {
                        result.TotalRecords = (from x in db.Warehouses select x).Count();
                        result.data = (from x in db.Warehouses orderby x.Id descending select x)
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

        #region attribute

        public ResponseCls AddAttribute(RequestCls obj)
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
                        Attribute resp = (from x in db.Attributes where x.Id == obj.Id select x).FirstOrDefault();
                        if (resp != null)
                        {
                            resp.Name = obj.Name;
                            resp.Active = obj.Active;
                            //db.Items.Attach(resp);
                            db.Entry(resp).State = System.Data.Entity.EntityState.Modified;
                            result.message = "Data updated Succesfully";
                        }
                    }
                    else
                    {

                        Attribute attribute = new Attribute();
                        attribute.Name = obj.Name;
                        attribute.Active = obj.Active;
                        db.Attributes.Add(attribute);


                    }

                    db.SaveChanges();




                }
            }
            //catch (Exception ex)
            //{

            //    result.message = ex.InnerException.Message.ToString();
            //    result.status = "Error";
            //    result.flag = 0;
            //}
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        result.message = validationError.PropertyName + validationError.ErrorMessage;
                    }
                }
            }

            return result;
        }

        public ResponseCls RemoveAttribute(RequestCls obj)
        {
            ResponseCls result = new ResponseCls();


            try
            {

                using (var db = dbEntity)
                {
                    if (obj.Id > 0)
                    {
                        Attribute resp = (from x in db.Attributes where x.Id == obj.Id select x).FirstOrDefault();
                        db.Attributes.Remove(resp);
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

        public AttributeRespCls GetAtttribute(RequestParam obj)
        {
            AttributeRespCls result = new AttributeRespCls();
            result.message = "Success";
            result.TotalRecords = 0;
            result.data = null;


            try
            {

                using (var db = new Inventory_AnftonEntities())
                {
                    if (!string.IsNullOrEmpty(obj.Search))
                    {
                        result.TotalRecords = (from x in db.Attributes where x.Name.Contains(obj.Search) select x).Count();
                        result.data = (from x in db.Attributes where x.Name.Contains(obj.Search) orderby x.Id descending select x)
                            .Skip((obj.PageNo == 0 ? 0 : obj.PageNo - 1) * obj.PageLength)
                            .Take(obj.PageLength)
                            .ToList();
                    }
                    else
                    {
                        result.TotalRecords = (from x in db.Attributes select x).Count();
                        result.data = (from x in db.Attributes orderby x.Id descending select x)
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

        #region Product
        public ResponseCls AddProduct(ProductReq obj)
        {
            ResponseCls result = new ResponseCls();
            result.message = "Data Saved Successfully";
            result.status = "Succes";
            result.flag = 1;

            try
            {

                using (var db = dbEntity)
                {

                        Product product = new Product();
                        product.Name =obj.Name;
                        product.Price = Convert.ToDecimal( obj.Price);
                        product.Quantity = obj.Quantity;
                        product.Item = obj.Item;
                        product.Category = obj.Category;
                        product.Warehouse = obj.warhouse;
                        product.Availability = obj.Availibility;
                        db.Products.Add(product);
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

        public ProductRespCls ProductDetails(RequestParam obj)
        {
            ProductRespCls result = new ProductRespCls();
            result.message = "Success";
            result.TotalRecords = 0;
            result.data = null;


            try
            {

                using (var db = new Inventory_AnftonEntities())
                {
                    if (!string.IsNullOrEmpty(obj.Search))
                    {
                        result.TotalRecords = (from x in db.Products where x.Name.Contains(obj.Search) select x).Count();
                        var data = (from x in db.Products
                                    join y in db.Items on x.Item equals y.Id
                                    join c in db.Categories on x.Category equals c.Id
                                    join v in db.Warehouses on x.Warehouse equals v.Id

                                    where x.Name.Contains(obj.Search) 
                                    orderby x.Id descending
                                    select new productDTO
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Price = x.Price.ToString(),
                                        Quantity = (int)x.Quantity,
                                        Item = y.Name,
                                        Category = c.Name,
                                        warhouse = v.Name,
                                        Availibility = x.Availability

                                    } )
                            .Skip((obj.PageNo == 0 ? 0 : obj.PageNo - 1) * obj.PageLength)
                            .Take(obj.PageLength)
                            .ToList();
                    }
                    else
                    {
                        result.TotalRecords = (from x in db.Products select x).Count();
                        var data = (from x in db.Products join y in db.Items on x.Item equals y.Id
                                    join c in db.Categories on x.Category equals c.Id
                                    join v in db.Warehouses on x.Warehouse equals v.Id


                                    orderby x.Id descending select new productDTO {
                                        Id=x.Id,
                                        Name = x.Name,
                                        Price = x.Price.ToString(),
                                        Quantity= (int)x.Quantity,
                                        Item=y.Name,
                                        Category=c.Name,
                                        warhouse=v.Name,
                                        Availibility=x.Availability

                                    })
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