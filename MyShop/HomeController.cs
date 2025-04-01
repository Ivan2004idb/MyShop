using Microsoft.AspNetCore.Mvc;
using MyShop.Data;
using MyShop.Models;
using System.Linq;

namespace MyShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // Извлечение всех продуктов из базы данных
            var products = _db.Products.ToList();

            // Передаем продукты в представление
            return View(products);
        }
    }
}
