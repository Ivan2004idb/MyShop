using Microsoft.AspNetCore.Mvc;
using MyShop.Data;
using MyShop.Models;
using System.Linq;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SearchController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Ok(new { results = new string[0] });
            }

            var results = _db.SearchKeywords
                .Where(k => k.Keyword.Contains(query))
                .Select(k => new { k.Keyword, k.PagePath })
                .ToList();

            return Ok(new { results });
        }
    }
}
