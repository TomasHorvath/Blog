using AutoMapper;
using System;
using System.Collections.Generic;
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

		public ActionResult Index(int? pageSize, int? page)

		{

			var PageNumber = (page ?? 0);
			var PageSize = (pageSize ?? 1);
			var totalRowCount = 0;

			var blogPosts = _blogService.GetByPage(PageSize,PageNumber, out totalRowCount);
			if (Request.IsAjaxRequest())
			{
				return Json(
					new
				{
					HasPreviosPage = blogPosts.HasPreviousPage,
					HasNextPage = blogPosts.HasNextPage,
					Items = blogPosts,
					PageIndex = blogPosts.PageIndex,
					PageSize = blogPosts.PageSize,
					TotalPage = blogPosts.TotalCount
				},JsonRequestBehavior.AllowGet);
			}
			else
			{
				return View(blogPosts);
			}
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