using Microsoft.AspNetCore.Mvc;
using QuanLy_ShopConCung.Data;

namespace QuanLy_ShopConCung.Components
{
    public class Navbar: ViewComponent
    {
		private readonly ApplicationDbContext _context;

		public Navbar(ApplicationDbContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
        {
            return View(_context.Categories.ToList());
        }
    }
}
