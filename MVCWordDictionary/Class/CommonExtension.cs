using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Xml.Linq;

namespace MVCWordDictionary
{
    public static class Extention
    {
        public static string GetValueElement(this XElement element, XName xName)
        {
            string result = string.Empty;
            if (element.Element(xName) != null)
            {
                result = element.Element(xName).Value;
            }
            return result;
        }

        public static MvcHtmlString CustomImage(this HtmlHelper htmlHelper, string src, string alt, int width, int height = 0)
        {
            var imageTag = new TagBuilder("image");
            imageTag.MergeAttribute("src", src);
            imageTag.MergeAttribute("alt", alt);
            imageTag.MergeAttribute("width", width.ToString());
            if (height != 0)
            {
                imageTag.MergeAttribute("height", height.ToString());
            }
            return MvcHtmlString.Create(imageTag.ToString(TagRenderMode.SelfClosing));
        }


        public static MvcHtmlString CustomImage(this HtmlHelper htmlHelper, string src, string alt, string className)
        {
            var imageTag = new TagBuilder("image");
            imageTag.MergeAttribute("src", src);
            imageTag.MergeAttribute("alt", alt);
            imageTag.MergeAttribute("class", className);

            return MvcHtmlString.Create(imageTag.ToString(TagRenderMode.SelfClosing));
        }

        public static HtmlString RenderScripts(this HtmlHelper htmlHelpr)
        {
            var scripts = htmlHelpr.ViewContext.HttpContext.Items["Scripts"] as IList<string>;
            if (scripts != null)
            {
                var builder = new StringBuilder();
                foreach (var script in scripts)
                {
                    builder.AppendLine(script);
                }
                return new MvcHtmlString(builder.ToString());

            }
            return null;
        }

        public static HelperResult RenderSection(this WebPageBase webPage, string name, Func<dynamic, HelperResult> defaultContents)
        {
            if (webPage.IsSectionDefined(name))
            {
                return webPage.RenderSection(name);
            }
            return defaultContents(null);
        }

    }
}