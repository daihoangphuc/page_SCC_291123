
using System.ComponentModel.DataAnnotations;

namespace QuanLy_ShopConCung.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public string? UserPassword { get; set; }


        public string? UserRole { get; set; }
    }
}
