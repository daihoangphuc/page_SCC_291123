using Microsoft.AspNetCore.Mvc;
using QuanLy_ShopConCung.Data;

namespace QuanLy_ShopConCung.Components
{
	public class Productshow:ViewComponent
	{
		private readonly ApplicationDbContext _context;

		public Productshow(ApplicationDbContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			return View( _context.Products.ToList());
		}
	}
}
