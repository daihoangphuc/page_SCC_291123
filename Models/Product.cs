using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace QuanLy_ShopConCung.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(150)]
        public string? ProductName { get; set; }
        [StringLength(30000)]

        public string? ProductDescription { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

		[Column(TypeName = "int")] // Đặt kiểu dữ liệu mới của cột
		public int ProductPrice { get; set; }

        [Column(TypeName = "decimal(2,2)")]

        public decimal? ProductDiscount { get; set; }
        [StringLength(300)]

        public string? ProductPhoto { get; set; }
        [ForeignKey("Size")]

        public int SizeId { get; set; }
        public Size? Size { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}
