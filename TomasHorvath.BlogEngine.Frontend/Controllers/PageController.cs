using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TomasHorvath.BlogEngine.Frontend.Controllers
{
	public class PageController : Controller
	{
		private readonly BL.Interface.IPageService _pageService;

		public PageController(BL.Interface.IPageService pageService)
		{
			_pageService = pageService;
		}
		public ActionResult Index()
		{
			return View();
		}

		[ChildActionOnly]
		public PartialViewResult Menu()
		{
			var model = _pageService.GetMenu();
			return PartialView(model);
		}
	}
}