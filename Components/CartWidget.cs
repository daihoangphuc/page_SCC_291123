using Microsoft.AspNetCore.Mvc;
using QuanLy_ShopConCung.Data;
using QuanLy_ShopConCung.Infrastructure;
using QuanLy_ShopConCung.Models;

namespace QuanLy_ShopConCung.Components
{
	public class CartWidget : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View(HttpContext.Session.GetJson<Cart>("cart"));
		}
	}
}
