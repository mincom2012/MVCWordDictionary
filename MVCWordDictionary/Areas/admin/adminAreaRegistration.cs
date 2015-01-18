using System.Web.Mvc;

namespace MVCWordDictionary.Admin
{
    public class adminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "admin";
            }
        }

        public override void RegisterArea( AreaRegistrationContext context )
        {

            //News
            context.MapRoute(
                "admin_news",
                "admin/News/{action}/{id}",
                new { controller = "News", action = "index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "admin_comment",
                "admin/comment/{action}/{id}",
                new { controller = "comment", action = "index", id = UrlParameter.Optional }
            );


            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}