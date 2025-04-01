using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MyShop.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Удаляем аутентификационную куку
            await HttpContext.SignOutAsync("MyCookieAuth");

            // Перенаправляем пользователя на главную страницу
            return RedirectToAction("Index", "Home");
        }
    }
}
