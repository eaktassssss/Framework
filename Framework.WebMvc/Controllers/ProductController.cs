﻿using System;
using System.Diagnostics.CodeAnalysis;
using Framework.Business.Abstract;
using Framework.DataAccess.Context;
using Framework.DTO.Products;
using System.Linq;
using System.Web.Mvc;
namespace Framework.WebMvc.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult Add()
        {
            TempData["CategoryList"] = _categoryService.GetCategoryDropdownList();
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductDto product)
        {

            try
            {
                _productService.Add(product);
                return View();
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
           
        }
        [HttpGet]
        public ActionResult List()
        {
            try
            {
                var result = _productService.GetProductList(null);
                return View(result);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                var product = _productService.Get(x => x.ProductID == id);
                if (product != null)
                {
                    return View(product);
                }
                return View();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpPost]
        public ActionResult Update(ProductDto product)
        {
            try
            {
                var model = _productService.Get(p=> p.ProductID==p.ProductID);
                if (model !=null)
                {
                    model.ProductID = product.ProductID;
                    model.ProductName = product.ProductName;
                    model.QuantityPerUnit = product.QuantityPerUnit;
                    model.ReorderLevel = product.ReorderLevel;
                    model.SupplierID = product.SupplierID;
                    model.UnitPrice = product.UnitPrice;
                    model.UnitsInStock = product.UnitsInStock;
                    model.UnitsOnOrder = product.UnitsOnOrder;
                    model.Discontinued = product.Discontinued;
                    _productService.Update(model);
                    return RedirectToAction("List","Product");
                }
                return View(product);

            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return RedirectToAction("List", "Product");
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
        }
    }
}