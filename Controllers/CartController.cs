using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using NuGet.Protocol.Core.Types;
using QuanLy_ShopConCung.Data;
using QuanLy_ShopConCung.Infrastructure;
using QuanLy_ShopConCung.Models;

namespace QuanLy_ShopConCung.Controllers
{
	public class CartController : Controller
	{
		public Cart? Cart { get; set; }
		private readonly ApplicationDbContext _context;

		public CartController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View("Cart", HttpContext.Session.GetJson<Cart>("cart"));
		}
		public IActionResult ShowCart(int productId)
		{
			Product? product = _context.Products
 .FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
				
				HttpContext.Session.SetJson("cart", Cart);
			}
			return View("Cart", Cart);
		}


		public IActionResult AddToCart(int productId)
		{
			Product? product = _context.Products
 .FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
				Cart.AddItem(product, 1);
				HttpContext.Session.SetJson("cart", Cart);
			}
			return View("Cart", Cart);
		}


		public IActionResult RemoveFromCart(int productId)
		{
			Product? product = _context.Products
 .FirstOrDefault(p => p.ProductId == productId);
			if (product != null)
			{
				Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
				Cart.RemoveLine(product);
				HttpContext.Session.SetJson("cart", Cart);
			}
			return View("Cart", Cart);
		}





		public IActionResult UpdateFromCart(int productId, int quantity)
		{
			Product? product = _context.Products
				.FirstOrDefault(p => p.ProductId == productId);

			if (product != null)
			{
				Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
				Cart.UpdateItem(product, quantity);
				HttpContext.Session.SetJson("cart", Cart);
			}

			return View("Cart", Cart);
		}




		// Trong CartController
		public IActionResult IncreaseQuantity(int productId)
		{
			Product? product = _context.Products
				.FirstOrDefault(p => p.ProductId == productId);

			if (product != null)
			{
				Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
				Cart.IncreaseQuantity(product);
				HttpContext.Session.SetJson("cart", Cart);
			}

			return View("Cart", Cart);
		}

		public IActionResult DecreaseQuantity(int productId)
		{
			Product? product = _context.Products
				.FirstOrDefault(p => p.ProductId == productId);

			if (product != null)
			{
				Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
				Cart.DecreaseQuantity(product);
				HttpContext.Session.SetJson("cart", Cart);
			}

			return View("Cart", Cart);
		}





	}
}
