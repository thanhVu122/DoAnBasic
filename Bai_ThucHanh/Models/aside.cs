using Bai_ThucHanh.Data;
using Microsoft.AspNetCore.Mvc;

namespace Bai_ThucHanh.Models
{
	public class aside :ViewComponent
	{
		private readonly Bai_ThucHanhContext _context;

		public aside(Bai_ThucHanhContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			return View(_context.Category.ToList());
		}
	}
}
