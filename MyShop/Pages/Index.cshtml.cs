using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Models;
using MyShop.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Product> Products { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            // ��������� ��� �������� �� ���� ������
            Products = _db.Products.ToList();
        }

        public IActionResult OnGetDetails(int id)
        {
            // �������� ������� �� ���� ������ �� ��� ID
            var product = _db.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            // ������� ���� � ����������� � �������������
            return RedirectToPage("/ProductDetails", new { id = product.Id });
        }

    }
}

