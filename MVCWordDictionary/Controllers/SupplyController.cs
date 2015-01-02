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
    public class SupplyController : Controller, IActionFilter
    {
        IRepository<Suppliers> db = new SupplyRepository();
        public List<int> lstSupplyDelete = new List<int>();

        // GET: /Supply/
        public ActionResult Index(int? pageIndex)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            IQueryable<Suppliers> supplyAll = db.GetAll();
            ViewData["RowCounts"] = supplyAll.Count();
            ViewData["PageIndex"] = pageIndex.Value;
            var lstSupply = supplyAll.OrderBy(x => x.CompanyName).ToPagedList(pageIndex.Value, 20);
            return View(lstSupply);
        }

        // GET: /Supply/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suppliers suppliers = db.GetDetail(id.Value);
            if (suppliers == null)
            {
                return HttpNotFound();
            }
            return View(suppliers);
        }

        // GET: /Supply/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Supply/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage")] Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                //db.Suppliers.Add(suppliers);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suppliers);
        }

        // GET: /Supply/Edit/5
        public ActionResult Edit(int? id)
        {
            //List<SelectListItem> lstCountry = new List<SelectListItem>();
            //lstCountry.Add(new SelectListItem { Value ="Findland", Text="Findland" });
            //lstCountry.Add(new SelectListItem { Value = "VN", Text = "VietNam" });
            //lstCountry.Add(new SelectListItem { Value = "Lao", Text = "Lao" });
            //lstCountry.Add(new SelectListItem { Value = "campuchia", Text = "Campuchia" });

            //ViewBag.lstCountry = lstCountry;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suppliers suppliers = db.GetDetail(id.Value);
            if (suppliers == null)
            {
                return HttpNotFound();
            }

            suppliers.Locations = new List<Location>() {
                                        new Location(){LocationID ="Findland", LocationName="findland"},
                                        new Location(){LocationID ="VN", LocationName="Vietnam"},
                                        new Location(){LocationID ="Lao", LocationName="Lao"},
                                        new Location(){LocationID ="Campuchia", LocationName="Campuchia"}};

            ViewBag.lstCountry = suppliers.Locations.Select(x => new SelectListItem { Value = x.LocationID, Text = x.LocationName }).ToList();

            return View(suppliers);
        }

        // POST: /Supply/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage")] Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(suppliers).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suppliers);
        }

        // GET: /Supply/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suppliers suppliers = db.GetDetail(id.Value);
            if (suppliers == null)
            {
                return HttpNotFound();
            }
            return View(suppliers);
        }

        // POST: /Supply/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Suppliers suppliers = db.Suppliers.Find(id);
            //db.Suppliers.Remove(suppliers);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult DeleteAll(string productIDs)
        {
            var array = productIDs.Split(';').ToList();
            for (int i = 0; i < array.Count; i++)
            {
                int productID = Convert.ToInt16(array[i]);
                db.Delete(productID);
            }
            db.Save();

            return Json("Delete completed!");
        }

        public JsonResult SelectSupply(int id)
        {
            if (lstSupplyDelete.Contains(id))
            {
                lstSupplyDelete.Remove(id);
            }
            else
            {
                lstSupplyDelete.Add(id);
            }

            return Json("minh 123");
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}
