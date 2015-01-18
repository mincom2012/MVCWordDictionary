using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWordDictionary.Controllers
{
    public interface IBaseController<T>
    {
        ActionResult Index(int? pageIndex);

        ActionResult Show();

        [HttpGet]
        ActionResult New();

        [HttpPost]
        ActionResult Create(T obj);

        [HttpGet]
        ActionResult Edit(object id);

        [HttpPut]
        ActionResult Update(T obj);

        [HttpDelete]
        ActionResult Delete(object id);

    }
}