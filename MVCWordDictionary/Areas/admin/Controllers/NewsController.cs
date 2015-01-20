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
using MVCWordDictionary.Enumeration;
using System.IO;
using System.Configuration;
using MVCWordDictionary.Controllers;
using MVCWordDictionary.ControlHelpers;

namespace MVCWordDictionary.Admin.Controllers
{
    public class NewsController : Controller, IBaseController<News>
    {
        IRepository<News> service = new NewsRepository();

        #region "Interface"



        public ActionResult Index( int? pageIndex )
        {
            IQueryable<News> lst = service.GetAll();
            ViewData["RowCounts"] = lst.Count();
            ViewData["PageIndex"] = pageIndex == null ? 0 : pageIndex;

            ViewBag.DisplayDescription = true;
            if ( Request.QueryString["Mode"] == null || Request.QueryString["Mode"] == "list" )
            {
                ViewBag.DisplayDescription = false;
            }

            return View(lst);
        }

        public ActionResult QuickEdit( Guid id )
        {

            var news = service.GetDetail(id);
            //var obj = RenderHelper("~/Views/Shared/QuickEditNewsPartial.cshtml", news);
            var obj = RenderHelper.PartialView(this, "~/Views/Shared/QuickEditNewsPartial.cshtml", news);

            return PartialView("~/Views/Shared/QuickEditNewsPartial.cshtml", news);
            //return Json(obj);
        }

        [HttpPost]
        public ActionResult QuickEditUpdate( Guid id, string title, string description )
        {
            var news = service.GetDetail(id);
            news.Title = title;
            news.Description = description;
            news.ModifiedDate = DateTime.Now;
            service.Update(news);
            service.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Show()
        {
            throw new NotImplementedException();
        }

        public ActionResult New()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            var lst1 = Enum.GetValues(typeof(NewsType));
            foreach ( var item in lst1 )
            {
                var obj = EnumResource.ResourceManager.GetString(typeof(NewsType).Name + "_" + item.ToString());
                lst.Add(new SelectListItem { Value = Convert.ToInt32(item).ToString(), Text = obj });

            }

            ViewBag.lstNewType = lst;

            return View("AddNews");
        }

        public ActionResult Create( News obj )
        {
            var imgthumb = Request.Files["imageThumb"];

            if ( imgthumb != null && imgthumb.ContentLength > 0 )
            {
                var fileName = Path.GetFileName(imgthumb.FileName);
                string imageNews_thumb = ConfigurationManager.AppSettings["ImageNews_Thumb"].ToString();
                var path = Path.Combine(Server.MapPath(imageNews_thumb), fileName);
                imgthumb.SaveAs(path);
                obj.ImageThumb = fileName;
            }

            obj.ModifiedDate = DateTime.Now;

            if ( obj.NewID == Guid.Empty )
            {
                obj.NewID = Guid.NewGuid();
                obj.CreatedDate = DateTime.Now;
                service.Insert(obj);
            }
            else
            {
                service.Update(obj);
            }

            service.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit( object id )
        {
            var news = service.GetDetail(new Guid(id.ToString()));
            if ( news == null )
            {
                throw new Exception("The record not exists.");
            }

            List<SelectListItem> lst = new List<SelectListItem>();

            var lst1 = Enum.GetValues(typeof(NewsType));
            foreach ( var item in lst1 )
            {
                var obj = EnumResource.ResourceManager.GetString(typeof(NewsType).Name + "_" + item.ToString());
                lst.Add(new SelectListItem { Value = Convert.ToInt32(item).ToString(), Text = obj });

            }

            ViewBag.lstNewType = lst;

            var result = Json(news, JsonRequestBehavior.AllowGet);
            return View("AddNews", news);

        }

        public ActionResult Update( News obj )
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete( object id )
        {
            service.Delete(new Guid(id.ToString()));
            service.Save();
            return RedirectToAction("Index");

        }

        public ActionResult Detail( Guid id )
        {
            var news = service.GetDetail(id);
            if ( news == null )
            {
                throw new Exception("Do not item");
            }

            return View("DetailNews", news);
        }

        #endregion

        #region "Internal Method"


        
        //Preview when add new or edit 
        [HttpPost]
        public ActionResult Preview( News model )
        {
            if ( model == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View("Preview", model);
        }

        //Preview when press key link
        public ActionResult Preview( Guid? id )
        {
            if ( id == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var news = service.GetDetail(id.Value);

            if ( news == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View("Preview", news);
        }

        #endregion
    }
}

