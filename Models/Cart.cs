using QuanLy_ShopConCung.Models;
using System.Linq;

namespace QuanLy_ShopConCung.Models
{
	public class Cart
	{
		public List<CartLine> Lines { get; set; } = new List<CartLine>();
		public void AddItem(Product product, int quantity)
		{
			CartLine? line = Lines
			.Where(p => p.Product.ProductId == product.ProductId)
			.FirstOrDefault();
			if (line == null)
			{
				Lines.Add(new CartLine
				{
					Product = product,
					Quantity = quantity
				});
			}
			else
			{
				line.Quantity += quantity;
			}
		}

		public void RemoveLine(Product product)
		{
			Lines.RemoveAll(l => l.Product.ProductId == product.ProductId);
		}

		public int ComputeTotalValues()
		{
			// Sử dụng LINQ để tính tổng giá trị
			int total = Lines.Sum(line => (line.Product?.ProductPrice ?? 0) * line.Quantity);
			return total;
		}
		public void Clear() => Lines.Clear();


		public void RemoveLineQuantity(Product product)
		{
			var line = Lines.FirstOrDefault(l => l.Product.ProductId == product.ProductId);

			if (line != null)
			{
				if (line.Quantity > 1)
				{
					line.Quantity--;
				}
				else
				{
					Lines.RemoveAll(l => l.Product.ProductId == product.ProductId);
				}
			}
		}

		public void UpdateItem(Product product, int quantity)
		{
			var line = Lines.FirstOrDefault(p => p.Product.ProductId == product.ProductId);

			if (line != null)
			{
				line.Quantity = quantity;
			}
		}


		// Trong lớp Cart
		public void IncreaseQuantity(Product product)
		{
			var line = Lines.FirstOrDefault(l => l.Product.ProductId == product.ProductId);

			if (line != null)
			{
				line.Quantity++;
			}
		}

		public void DecreaseQuantity(Product product)
		{
			var line = Lines.FirstOrDefault(l => l.Product.ProductId == product.ProductId);

			if (line != null && line.Quantity > 1)
			{
				line.Quantity--;
			}
			else
			{
				Lines.RemoveAll(l => l.Product.ProductId == product.ProductId);
			}
		}




	}


	public class CartLine
	{
		public int CartLineID { get; set; }
		public Product Product { get; set; } = new();
		public int Quantity { get; set; }
	}
}
