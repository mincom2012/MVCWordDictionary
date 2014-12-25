using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWordDictionary.Models;

namespace MVCWordDictionary.Controllers
{
    public class WordController : Controller
    {
        private WordManagerEntities db = new WordManagerEntities();

        // GET: /Word/
        public ActionResult Index()
        {
            var word = db.Word.Include(w => w.Category);
            return View(word.ToList());
        }

        // GET: /Word/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = db.Word.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        // GET: /Word/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName");
            return View();
        }

        // POST: /Word/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="WordID,WordName,Created,Modified,CategoryID")] Word word)
        {
            if (ModelState.IsValid)
            {
                db.Word.Add(word);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName", word.CategoryID);
            return View(word);
        }

        // GET: /Word/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = db.Word.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName", word.CategoryID);
            return View(word);
        }

        // POST: /Word/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="WordID,WordName,Created,Modified,CategoryID")] Word word)
        {
            if (ModelState.IsValid)
            {
                db.Entry(word).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName", word.CategoryID);
            return View(word);
        }

        // GET: /Word/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = db.Word.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        // POST: /Word/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Word word = db.Word.Find(id);
            db.Word.Remove(word);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
