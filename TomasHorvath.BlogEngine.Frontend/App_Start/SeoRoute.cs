using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace TomasHorvath.BlogEngine.Frontend.App_Start
{
	public class SeoRoute : Route
	{
		private readonly BL.Interface.ISlugService urlService;
		public SeoRoute(string url, IRouteHandler routeHandler, BL.Interface.ISlugService urls)
				: base(url, routeHandler)
		{
			urlService = urls;
		}
		public override RouteData GetRouteData(HttpContextBase httpContext)
		{
			RouteData data = base.GetRouteData(httpContext);

			if (data != null)
			{
				var SeoFriendliyName = data.Values["SeoFriendlyName"] as string;

				var UrlRecord = urlService.GetBySlug(SeoFriendliyName);

				if (UrlRecord != null)
				{
					switch (UrlRecord.EntityType)
					{
						case Domain.EntityType.BlogPost:
							data.Values["controller"] = "BlogPost";
							data.Values["action"] = "Detail";
							data.Values["Id"] = UrlRecord.EntityId; break;

						case Domain.EntityType.Page:
							data.Values["controller"] = "Page";
							data.Values["action"] = "Detail";
							data.Values["Id"] = UrlRecord.EntityId; break;
					}
				}
				else
				{
					// Add Error page here.
				}
			}
			return data;
		}

	}
}
