using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MVC_Web.Models;
using MVC_DomainEntities;
using MVC_BLL;
using MVC_Web.LinqToSQLClasses;

namespace MVC_Web.Controllers
{
    public class CategoryController : Controller
    {

        private ICategoryService ICategoryService;
        private ILoggerService ILoggerService;

        //public CategoryController(ICategoryService Icat, ILoggerService ILS)
        //{
        //    ICategoryService = Icat;
        //    ILoggerService = ILS;
        //}

        #region Action Methods

        // GET: /Category/
        public ActionResult Index()
        {
            try
            {

                string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["StoreDBConnectionString"].ToString();

                List<CategoryModel> model = null;

                using (LinqToSQLDataContextDataContext context = new LinqToSQLDataContextDataContext(connectString))
                {
                    IEnumerable<LinqToSQLClasses.Category> cat = context.Categories.ToList();
                    Mapper.CreateMap<LinqToSQLClasses.Category, CategoryModel>();
                    model = Mapper.Map<IEnumerable<LinqToSQLClasses.Category>, List<CategoryModel>>(cat);
                }

                //IEnumerable<Category> cat = ICategoryService.CategoryList();
                //Mapper.CreateMap<Category, CategoryModel>();
                //IEnumerable<CategoryModel> model = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(cat);

                return View(model);
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("CategoryController-Index", ex.ToString());
                return View();
            }
        }

        // GET: /Category/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Name")] CategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Mapper.CreateMap<CategoryModel, MVC_DomainEntities.Category>();
                    MVC_DomainEntities.Category category = Mapper.Map<MVC_DomainEntities.Category>(model);
                    ICategoryService.AddCategory(category);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("CategoryController-Create", ex.ToString());
            }

            return View(model);
        }

        // GET: /Category/Details/5
        public ActionResult Details(int? Id)
        {
            try
            {
                MVC_DomainEntities.Category category = ICategoryService.GetCategory(Id);
                Mapper.CreateMap<MVC_DomainEntities.Category, CategoryModel>();
                CategoryModel model = Mapper.Map<CategoryModel>(category);
                
                return View(model);
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("CategoryController-Details", ex.ToString());
                return View();
            }
        }

        // GET: /Category/Delete/5
        [Authorize]
        public ActionResult Delete(int? Id)
        {
            try
            {
                MVC_DomainEntities.Category category = ICategoryService.GetCategory(Id);
                Mapper.CreateMap<MVC_DomainEntities.Category, CategoryModel>();
                CategoryModel model = Mapper.Map<CategoryModel>(category);
                
                return View(model);
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("CategoryController-Delete", ex.ToString());
                return View();
            }
        }

        // POST: /Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            try
            {
                ICategoryService.DeleteCategory(Id);
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("CategoryController-DeleteConfirmed", ex.ToString());
                return View();
            }
        }

        // GET: /Category/Edit/5
        [Authorize]
        public ActionResult Edit(int? Id)
        {
            try
            {
                MVC_DomainEntities.Category category = ICategoryService.GetCategory(Id);
                Mapper.CreateMap<MVC_DomainEntities.Category, CategoryModel>();
                CategoryModel model = Mapper.Map<CategoryModel>(category);

                return View(model);
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("CategoryController-Edit", ex.ToString());
                return View();
            }
        }

        // POST: /Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,Name")] CategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Mapper.CreateMap<CategoryModel, MVC_DomainEntities.Category>();
                    MVC_DomainEntities.Category category = Mapper.Map<MVC_DomainEntities.Category>(model);
                    ICategoryService.EditCategory(category);
                    
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ILoggerService.AddLogger("CategoryController-Edit", ex.ToString());
            }
            return View(model);
        }

        #endregion

    }
}
