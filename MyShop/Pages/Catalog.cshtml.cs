using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Data;
using MyShop.Models;
using MyShop.Utils;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Pages
{
    public class CatalogModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Product> Products { get; set; }

        public CatalogModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Products = _db.Products.ToList();
        }

        // ���������� ��� ������ "�������� � �������"
        public IActionResult OnPostAddToCart(int productId)
        {
            // ������� ����� � ���� ������
            var product = _db.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                return NotFound();
            }

            // ������� ������� �������
            var cartItem = new CartItems
            {
                ProductId = product.Id,
                Name = product.Name,
                Quantity = 1,
                Price = product.Price
            };

            // ��������� ����� � ������� (������)
            CartHelper.AddToCart(HttpContext.Session, cartItem);

            // �������������� �� �������� �������
            return RedirectToPage("/Catalog");
        }
    }
}
