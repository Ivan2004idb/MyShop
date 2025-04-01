using Microsoft.AspNetCore.Mvc;
using MyShop.Utils;

namespace MyShop.Controllers
{
    public class CartController : Controller
    {
        // Действие для очистки корзины
        [HttpPost]
        public IActionResult ClearCart()
        {
            // Очистка корзины
            CartHelper.ClearCart(HttpContext.Session);

            // Перенаправляем пользователя обратно на страницу корзины
            return RedirectToAction("Index");
        }

        // Действие для отображения корзины
        public IActionResult Index()
        {
            var cart = CartHelper.GetCart(HttpContext.Session);
            return View(cart);  // Возвращаем представление с корзиной
        }
        [HttpPost]
        public IActionResult UpdateQuantity([FromBody] UpdateQuantityRequest request)
        {
            CartHelper.UpdateQuantity(HttpContext.Session, request.ProductId, request.Change);
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult RemoveFromCart([FromBody] RemoveFromCartRequest request)
        {
            CartHelper.RemoveItem(HttpContext.Session, request.ProductId);
            return Json(new { success = true });
        }

        public class UpdateQuantityRequest
        {
            public int ProductId { get; set; }
            public int Change { get; set; }
        }

        public class RemoveFromCartRequest
        {
            public int ProductId { get; set; }
        }

    }
}
