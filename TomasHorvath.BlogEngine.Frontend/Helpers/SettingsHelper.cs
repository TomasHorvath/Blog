using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TomasHorvath.BlogEngine.Frontend.Helpers
{
	public static class SettingsHelper
	{

		public static IHtmlString Setting(this HtmlHelper helper, string Key)
		{
			var settings = DependencyResolver.Current.GetService<BL.Interface.ISettingsService>();
			var result = settings.GetByKey(Key);
			return new HtmlString(result.Value);
		}

	}
}
