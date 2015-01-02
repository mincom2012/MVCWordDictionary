using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MVCWordDictionary
{
    public static class Extention
    {
        //public static IQueryable<T> ToPageList<T>(this IQueryable<T> lstAll, int pageNumber, int pageSize, out int rowsCount)
        //{
        //    if (pageSize <= 0)
        //    {
        //        pageSize = 20;
        //    }

        //    rowsCount = lstAll.Count();
        //    if (rowsCount <= pageSize || pageNumber <= 0)
        //    {
        //        pageNumber = 1;
        //    }


        //    int excludedRows = (pageNumber - 1) * pageSize;
        //    var objNew = Activator.CreateInstance<T>();

        //    lstAll = lstAll.OrderBy(x=> "CategoryName");

        //    return lstAll.Skip(excludedRows).Take(pageSize);
        //}

        public static string GetValueElement(this XElement element, XName xName)
        {
            string result = string.Empty;
            if (element.Element(xName) != null)
            {
                result = element.Element(xName).Value;
            }
            return result;
        }
    }
}