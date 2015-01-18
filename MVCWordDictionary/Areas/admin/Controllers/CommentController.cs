using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWordDictionary.Controllers;
using MVCWordDictionary.Models;

namespace MVCWordDictionary.Admin.Controllers
{
    public class CommentController : Controller, IBaseController<Comment>
    {
        IRepository<Comment> service = new CommentRespository();

        public ActionResult Index( int? pageIndex )
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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

        public ActionResult InsertComment( )
        {
            var comments = service.GetAll();
            return PartialView("~/Views/Shared/Comment/_InsertComment.cshtml", comments);
        }

        //Implement when submit in page news
        [HttpPost]
        public JsonResult InsertComment( Comment obj )
        {
            obj.CommentID = Guid.NewGuid();
            service.Insert(obj);
            service.Save();
            string result = "<li id='list-comment' class='list-group-item'> " + obj.Contents + " </li>";
            return Json(result);
        }
    }
}