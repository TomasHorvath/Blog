using System.Web;
using System.Web.Optimization;

namespace TomasHorvath.BlogEngine.Frontend.App_Start
{
	public class BundleConfig
	{

		public static void RegisterBundles(BundleCollection bundles)
		{

			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
								"~/Content/vendors/jquery/jquery.js",
								"~/Content/verdons/bootstrap/js/bootstrap.js",
								"~/Content/js/jqBootstrapValidation.js",
								"~/Content/js/clean-blog.js",
								"~/Content/js/contact_me.js"

							));


			bundles.Add(new StyleBundle("~/bootstrap").Include(
					"~/Content/verdons/bootstrap/bootstrap.css"
			));

			bundles.Add(new StyleBundle("~/Content/css").Include(
			"~/Content/css/clean-blog.css"
			));

			bundles.Add(new StyleBundle("~/Content/css/font-awesome").Include(
				"~/Content/verdons/font-awesome/css/font-awesome.css"
		));

		}
	}
}
