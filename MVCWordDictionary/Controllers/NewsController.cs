using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWordDictionary.Models;
using System.Web.Helpers;

namespace MVCWordDictionary.Controllers
{
    public class NewsController : Controller,  IBaseController<News>
    {
        IRepository<News> service = new NewsRepository();

        public ActionResult Index()
        {
            IQueryable<News> lst = service.GetAll();
            return View(lst);
        }

        public ActionResult Show()
        {
            throw new NotImplementedException();
        }

        public ActionResult New()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem { Value = "1", Text = "1" });
            lst.Add(new SelectListItem { Value = "2", Text = "2" });
            lst.Add(new SelectListItem { Value = "3", Text = "3" });
            ViewBag.lstNewType = lst;
            return View("AddNews");
        }

        public ActionResult Create(News obj)
        {
            var imgthumb = Request.Files["imageThumb"];
            var img = Request.Files["image"];
            return View();
        }

        public ActionResult Edit(object id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Update(News obj)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(object id)
        {
            throw new NotImplementedException();
        }


    }
}
