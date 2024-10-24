using Bai_ThucHanh.Data;
using Bai_ThucHanh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Bai_ThucHanh.Controllers
{
    public class HomeController : Controller
    {
		private readonly Bai_ThucHanhContext _context;

		public HomeController(Bai_ThucHanhContext context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
            return View(_context.Productcs.Include(p => p.Category).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
