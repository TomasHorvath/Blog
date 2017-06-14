using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TomasHorvath.BlogEngine.Frontend.Extensions;

namespace TomasHorvath.BlogEngine.Frontend
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapLocalizedRoute("SeoFriendlyUrl", "{SeoFriendlyName}",
																	 new { controller = "Company", action = "Index" }
																	 , new string[] { "Frontend.Controllers" });

			routes.MapRoute(
								name: "Default",
								url: "{controller}/{action}/{id}",
								defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
						);
		}
	}
}
