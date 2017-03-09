using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcRandomImage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Session", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ShowImage",
                url: "Image/Show",
                defaults: new { controller = "Image", action = "Show" }
            );

            routes.MapRoute(
                name: "GetImage",
                url: "Image/Get",
                defaults: new { controller = "Image", action = "Get" }
            );

            routes.MapRoute(
                name: "ShowLikedImage",
                url: "Image/Liked",
                defaults: new { controller = "Image", action = "Liked" }
            );

            routes.MapRoute(
                name: "ShowDisLikedImage",
                url: "Image/DisLiked",
                defaults: new { controller = "Image", action = "DisLiked" }
            );

            routes.MapRoute(
                name: "LikeImage",
                url: "Image/Like/{imageId}/{like}",
                defaults: new { controller = "Like", action = "Like", imageId = "", like = "" }
            );

            routes.MapRoute(
               name: "Logout",
               url: "Logout",
               defaults: new { controller = "Session", action = "Logout" }
           );
        }
    }
}
