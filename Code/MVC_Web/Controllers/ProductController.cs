using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AutoMapper;
using MVC_Web.Models;
using MVC_DomainEntities;
using MVC_BLL;

namespace MVC_Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {

        IProductService IProductService;
        ICategoryService ICategoryService;
        ILoggerService ILoggerService;

        public ProductController(IProductService Ips, ICategoryService Ics, ILoggerService ILS)
        {
            IProductService = Ips;
            ICategoryService = Ics;
            ILoggerService = ILS;
        }

        #region Action Methods

        // GET: /Product/
        public ActionResult Index()
        {
            try
            {
                IEnumerable<Product> ProductList = IProductService.UserProductsList(User.Identity.GetUserId());
                Mapper.CreateMap<Product, ProductModel>().ForMember(m => m.CategoryName, opt => opt.MapFrom(p => p.Category.Name));
                IEnumerable<ProductModel> model = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(ProductList);

                return View(model.ToList());
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("ProductController-Index", ex.ToString());
                return View();
            }
        }

        // GET: /Product/Details/5
        public ActionResult Details(int? Id)
        {
            try
            {
                ProductModel model = GetProductDetail(Id);
                return View(model);
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("ProductController-Details", ex.ToString());
                return View();
            }
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.CategoryId = new SelectList(ICategoryService.CategoryList(), "CategoryId", "Name");
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("ProductController-Create", ex.ToString());
            }
            return View();
        }

        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProductId,CategoryId,Name,Price")] ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Mapper.CreateMap<ProductModel, Product>();
                    Product product = Mapper.Map<ProductModel, Product>(model);

                    IProductService.AddProduct(product, User.Identity.GetUserId());
                    return RedirectToAction("Index");
                }

                ViewBag.CategoryId = new SelectList(ICategoryService.CategoryList(), "CategoryId", "Name", model.CategoryId);
                return View(model);
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("ProductController-Create", ex.ToString());
                return View();
            }
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(int? Id)
        {
            try
            {
                ProductModel model = GetProductDetail(Id);
                ViewBag.CategoryId = new SelectList(ICategoryService.CategoryList(), "CategoryId", "Name", model.CategoryId);
                return View(model);
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("ProductController-Edit", ex.ToString());
                return View();
            }
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,CategoryId,Name,Price")] ProductModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Mapper.CreateMap<ProductModel, Product>();
                    Product product = Mapper.Map<Product>(model);
                    IProductService.EditProduct(product);
                    return RedirectToAction("Index");
                }

                ViewBag.CategoryId = new SelectList(ICategoryService.CategoryList(), "CategoryId", "Name", model.CategoryId);
                return View(model);
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("ProductController-Edit", ex.ToString());
                return View();
            }
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(int? Id)
        {
            try
            {
                ProductModel model = GetProductDetail(Id);
                return View(model);
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("ProductController-Delete", ex.ToString());
                return View();
            }
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            try
            {
                IProductService.DeleteProduct(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("ProductController-DeleteConfirmed", ex.ToString());
                return View();
            }
        }

        #endregion

        private ProductModel GetProductDetail(int? Id)
        {
            Product product = IProductService.GetProduct(Id);
            Mapper.CreateMap<Product, ProductModel>();
            ProductModel model = Mapper.Map<ProductModel>(product);

            return model;
        }

    }
}
