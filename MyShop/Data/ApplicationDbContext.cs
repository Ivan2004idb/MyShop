using Microsoft.EntityFrameworkCore;
using MyShop.Models;
namespace MyShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<SearchKeyword> SearchKeywords { get; set; }

    }
}
