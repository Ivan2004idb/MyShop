using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Data;
using MyShop.Models;
using System.Threading.Tasks;

namespace MyShop.Pages
{
    public class FeedbackModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public FeedbackModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Получаем данные из формы
            var name = Request.Form["name"].ToString();
            var comment = Request.Form["comment"].ToString();
            var rating = Request.Form["rating"].ToString();
            var subscribe = Request.Form["subscribe"] == "on";
            var suggestions = Request.Form["suggestions"].ToString();

            var feedback = new Feedback
            {
                Name = name,
                Comment = comment,
                Rating = rating,
                Subscribe = subscribe,
                Suggestions = suggestions
            };

            // Сохраняем в базу
            _db.Feedbacks.Add(feedback);
            await _db.SaveChangesAsync();

            // Перенаправим на страницу "Спасибо"
            return RedirectToPage("/ThankYou");
        }
    }
}
