using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWordDictionary.Controllers
{

    public class ManagerController : Controller
    {
        //
        // GET: /Manager/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAllCategory() {
            return View();
        }

        public ActionResult ShowAllWord()
        {
            return View();
        }

        public ActionResult ShowAllUser()
        {
            return View();
        }
	}
}