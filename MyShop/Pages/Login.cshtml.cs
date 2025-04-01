using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BCrypt.Net;
using MyShop.Models;

namespace MyShop.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public LoginModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var login = Request.Form["login"].ToString();
            var password = Request.Form["password"].ToString();

            var user = _db.ApplicationUser.FirstOrDefault(u => u.Login == login);
            if (user == null)
            {
                ModelState.AddModelError("", "Неверный логин или пароль.");
                return Page();
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                ModelState.AddModelError("", "Неверный логин или пароль.");
                return Page();
            }

            // Создаем ClaimsPrincipal для аутентификации
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName)
            };
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("MyCookieAuth", principal);

            return RedirectToPage("/Index");
        }
    }
}
