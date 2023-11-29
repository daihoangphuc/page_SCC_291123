using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLy_ShopConCung.Models;

namespace QuanLy_ShopConCung.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Size> Sizes { get; set; }
        public DbSet<Models.Brand> Brands { get; set; }
        public DbSet<QuanLy_ShopConCung.Models.User>? User { get; set; }
    }
}