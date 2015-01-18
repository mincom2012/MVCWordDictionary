using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWordDictionary.Models;

namespace MVCWordDictionary.Controllers
{
    public class CommentController : Controller, IBaseController<Comment>
    {
        IRepository<Comment> service = new CommentRespository();

        public ActionResult Index( int? pageIndex )
        {
            var comements = service.GetAll();
            return View("Index", comements);
        }

        public ActionResult Show()
        {
            throw new NotImplementedException();
        }

        public ActionResult New()
        {
            throw new NotImplementedException();
        }

        public ActionResult Create( Comment obj )
        {
            service.Insert(obj);
            service.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit( object id )
        {
            throw new NotImplementedException();
        }

        public ActionResult Update( Comment obj )
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete( object id )
        {
            throw new NotImplementedException();
        }

        //Implement when submit in page news
        [HttpPost]
        public JsonResult InsertComment( Comment obj )
        {
            service.Insert(obj);
            service.Save();
            return Json(obj.Contents);
        }
    }
}