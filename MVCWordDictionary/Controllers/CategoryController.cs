using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWordDictionary.Models;
using PagedList;

namespace MVCWordDictionary.Controllers
{
    public class CategoryController : Controller
    {

        IRepository<Category> service = new CategoryRepository();

        public ActionResult Index(int? pageIndex, string sortOrder)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            ViewBag.SortingName = string.IsNullOrEmpty(sortOrder) ? "ASC" : "";
            
            IQueryable<Category> lstcategory = service.GetAll();
            ViewData["RowCounts"] = lstcategory.Count();
            ViewData["PageIndex"] = pageIndex;
            switch (sortOrder)
            {
                case "ASC":
                    lstcategory = lstcategory.OrderBy(x => x.CategoryName);
                    break;
                default:
                    lstcategory = lstcategory.OrderByDescending(x => x.CategoryName);
                    break;
            }

            List<Category> lst = lstcategory.ToList();
            var categoryAll = lstcategory.ToPagedList(pageIndex.Value, 20);
            return View(categoryAll);
        }

        // GET: /Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = service.GetDetail(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: /Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,Description,Created,Modified")] Category category)
        {
            if (ModelState.IsValid)
            {
                //db.Category.Add(category);
                //db.SaveChanges();
                service.Insert(category);
                service.Save();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: /Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = service.GetDetail(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: /Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,Description,Created,Modified")] Category category)
        {
            if (ModelState.IsValid)
            {
                service.Update(category);
                service.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        // GET: /Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = service.GetDetail(id.Value);

            if (Request.IsAjaxRequest())
            {
                if (category == null)
                {
                    return HttpNotFound();
                }
                service.Delete(id.Value);
                service.Save();
            }
            return RedirectToAction("Index");
        }

        public JsonResult CheckCategoryName(string categoryName)
        {
            var categoryAll = service.GetAll();
            var exist = categoryAll.Where(x => x.CategoryName == categoryName).FirstOrDefault();
            if (exist != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
