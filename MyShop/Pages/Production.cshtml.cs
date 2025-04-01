using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Data;
using MyShop.Models;

namespace MyShop.Pages
{
    public class ProductionModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Product> Products { get; set; }

        public ProductionModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Products = _db.Products.ToList();
        }
    }
}