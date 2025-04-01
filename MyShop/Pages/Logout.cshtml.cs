using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MyShop.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            // Удаляем аутентификационную куку
            await HttpContext.SignOutAsync("MyCookieAuth"); // Убедитесь, что имя схемы соответствует вашей конфигурации

            // Перенаправляем пользователя на главную страницу
            return RedirectToPage("Index");
        }
    }
}
