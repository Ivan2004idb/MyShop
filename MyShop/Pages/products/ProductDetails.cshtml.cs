using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Data;
using MyShop.Models;
using MyShop.Utils;
using System.Linq;

namespace MyShop.Pages.products
{
    public class ProductDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Product Product { get; set; }
        public string ProductDescription0 { get; set; }
        public string ProductDescription1 { get; set; }
        public string ProductDescription2 { get; set; }
        public string ProductDescription3 { get; set; }
        public string ProductDescription4 { get; set; }
        public string ProductDescription5 { get; set; }
        public string ProductDescription6 { get; set; }
        public string ProductDescription7 { get; set; }
        public string ProductDescription8 { get; set; }
        public string ProductDescription9 { get; set; }




        public ProductDetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int id)
        {
            // Ищем товар по ID
            Product = _db.Products.FirstOrDefault(p => p.Id == id);

            if (Product == null)
            {
                return NotFound();
            }

            ProductDescription0 = "Neoplan N122 3 (74) T 111 AM, мягкие откидные сиденья, 74 мест, Туалет, Wi-fi, DVD, 6 мониторов, Мини-кухня, Кондиционер";
            ProductDescription1 = "Neoplan N122 (70), 70 мест, мягкие откидные сиденья, Wi-fi, DVD, 6 мониторов, кондиционер";
            ProductDescription2 = "Neoplan SKYLINER N122 3 (75) В 444 СУ, мягкие откидные сидения, 75 мест, климат система, DVD, Wi-fi, 6 мониторов, кондиционер";
            ProductDescription3 = "Setra S 431 DT (78) С 007 УА, 78 мест, мягкие откидные сиденья, Wi-fi, DVD, 4 монитора, кондиционер";
            ProductDescription4 = "Setra S 431 DT (78) Т 008 МК, 78 мест, мягкие откидные сиденья, DVD, Wi-fi, 4 монитора, кондиционер ";
            ProductDescription5 = "Setra S 431 DT (78) Т 111 ОН, 78 мест, мягкие откидные сиденья, DVD, Wi-fi, 4 монитора, кондиционер";
            ProductDescription6 = "Москва - Ростов (14:00), Отправление: 14:00, Прибытие: 06:30, Стоимость: 1500р";
            ProductDescription7 = "Ростов - Москва (14:00), Отправление: 14:00, Прибытие: 06:30, Стоимость: 1500р";
            ProductDescription8 = "Москва - Ростов (20:00), Отправление: 20:00, Прибытие: 11:30, Стоимость: 1500р";
            ProductDescription9 = "Ростов - Москва (19:00), Отправление: 19:00, Прибытие: 11:30, Стоимость: 1500р";
            return Page();
        }

        // Обработчик для кнопки "Добавить в корзину"
        public IActionResult OnPostAddToCart(int productId)
        {
            // Находим товар в базе данных
            var product = _db.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                return NotFound();
            }

            // Создаем элемент корзины
            var cartItem = new CartItems
            {
                ProductId = product.Id,
                Name = product.Name,
                Quantity = 1,
                Price = product.Price
            };

            // Добавляем товар в корзину (сессия)
            CartHelper.AddToCart(HttpContext.Session, cartItem);

            // Перенаправляем на страницу корзины
            return RedirectToPage("/Catalog");
        }
    }
}
