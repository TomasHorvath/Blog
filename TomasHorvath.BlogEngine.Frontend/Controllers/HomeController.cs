using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TomasHorvath.BlogEngine.Frontend.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			ViewBag.Title = "Tomáš Horváth | .NET Developer";
			ViewBag.Keywords = "Tomáš Horváth,.NET,CORE,MVC,DDD";
			ViewBag.Description = "Tomáš Horváth developer blog";


			return View();
		}
	}
}