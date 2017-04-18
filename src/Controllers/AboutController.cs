using System.Collections.Generic;
using System.Linq;
using downr.Models;
using downr.Services;
using Microsoft.AspNetCore.Mvc;

namespace downr.Controllers
{
    public class AboutController : Controller
    {
        [Route("about")]
        public IActionResult Index(string slug)
        {
           return View();
        }
    }
}
