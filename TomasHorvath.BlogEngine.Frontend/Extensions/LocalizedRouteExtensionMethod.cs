﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using TomasHorvath.BlogEngine.Frontend.App_Start;

namespace TomasHorvath.BlogEngine.Frontend.Extensions
{
	public static class LocalizedRouteExtensionMethod
	{
		public static Route MapLocalizedRoute(this RouteCollection routes, string name, string url, object defaults, string[] namespaces)
		{
			return MapLocalizedRoute(routes, name, url, defaults, null /* constraints */, namespaces);
		}
		public static Route MapLocalizedRoute(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
		{
			if (routes == null)
			{
				throw new ArgumentNullException("routes");
			}
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}

			var urlservice = DependencyResolver.Current.GetService<BL.Interface.ISlugService>();

			var route = new SeoRoute(url, new MvcRouteHandler(), urlservice)
			{
				Defaults = new RouteValueDictionary(defaults),
				Constraints = new RouteValueDictionary(constraints),
				DataTokens = new RouteValueDictionary()
			};

			if ((namespaces != null) && (namespaces.Length > 0))
			{
				route.DataTokens["Namespaces"] = namespaces;
			}

			routes.Add(name, route);

			return route;
		}
	}
}
