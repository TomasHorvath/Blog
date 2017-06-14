using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TomasHorvath.BlogEngine.Domain;

namespace TomasHorvath.BlogEngine.Frontend.Controllers
{
	public class BlogPostController : Controller
	{
		private readonly BL.Interface.IBlogPostService _blogService;
		public BlogPostController(BL.Interface.IBlogPostService blog)
		{
			_blogService = blog;
		}

		public PartialViewResult Index(int? pageSize, int? page)
		{
			ViewBag.Root = ConfigurationManager.AppSettings["Root"];
			var PageNumber = (page ?? 0);
			var PageSize = (pageSize ?? 10);
			var totalRowCount = 0;

			var blogPosts = _blogService.GetByPage(PageSize, PageNumber, out totalRowCount);
			return PartialView(blogPosts);
		}

		public ActionResult Detail(Guid Id)
		{
			try
			{
				var model = _blogService.GetById(Id);
				return View(model);
			}
			catch (Exception ex)
			{
				return HttpNotFound();
			}
		}
	}
}