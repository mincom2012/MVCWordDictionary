using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace CustomHelpers
{
    public static class Extentions
    {

        public static MvcHtmlString CustomImage(this HtmlHelper htmlHelper, string src, string alt, int width, int height)
        {
            var imageTag = new TagBuilder("image");
            imageTag.MergeAttribute("src", src);
            imageTag.MergeAttribute("alt", alt);
            imageTag.MergeAttribute("width", width.ToString());
            imageTag.MergeAttribute("height", height.ToString());

            return MvcHtmlString.Create(imageTag.ToString(TagRenderMode.SelfClosing));
        }


        public static MvcHtmlString CustomImage( this HtmlHelper htmlHelper, string src, string alt, string className )
        {
            var imageTag = new TagBuilder("image");
            imageTag.MergeAttribute("src", src);
            imageTag.MergeAttribute("alt", alt);
            imageTag.MergeAttribute("class", className);

            return MvcHtmlString.Create(imageTag.ToString(TagRenderMode.SelfClosing));
        }



        public static HtmlString RenderScripts(this HtmlHelper htmlHelpr) {
            var scripts = htmlHelpr.ViewContext.HttpContext.Items["Scripts"] as IList<string>;
            if (scripts !=null)
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
    }
}