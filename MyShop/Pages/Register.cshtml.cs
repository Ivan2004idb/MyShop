using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Data;
using MyShop.Models;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net; // для хэширования паролей

namespace MyShop.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public RegisterModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var lastname = Request.Form["lastname"].ToString();
            var lastname2 = Request.Form["lastname2"].ToString();
            var number = Request.Form["number"].ToString();
            var firstname = Request.Form["firstname"].ToString();
            var login = Request.Form["login"].ToString();
            var password = Request.Form["password"].ToString();
            var policy = Request.Form["policy"].ToString() == "on";

            if (string.IsNullOrWhiteSpace(lastname) ||
                string.IsNullOrWhiteSpace(firstname) ||
                string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "Все поля обязательны.");
                return Page();
            }

            // Проверим уникальность логина
            if (_db.ApplicationUser.Any(u => u.Login == login))
            {
                ModelState.AddModelError("", "Пользователь с таким логином уже существует.");
                return Page();
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new ApplicationUser
            {
                LastName = lastname,
                FirstName = firstname,
                Login = login,
                PasswordHash = passwordHash,
                PolicyAgreed = policy,
                LastName2 = lastname2,
                Number = number,
            };

            _db.ApplicationUser.Add(user);
            await _db.SaveChangesAsync();

            // После регистрации можно сразу залогинить пользователя или попросить войти вручную
            return RedirectToPage("/Login");
        }
    }
}
