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
            // ���� ����� �� ID
            Product = _db.Products.FirstOrDefault(p => p.Id == id);

            if (Product == null)
            {
                return NotFound();
            }

            ProductDescription0 = "Neoplan N122 3 (74) T 111 AM, ������ �������� �������, 74 ����, ������, Wi-fi, DVD, 6 ���������, ����-�����, �����������";
            ProductDescription1 = "Neoplan N122 (70), 70 ����, ������ �������� �������, Wi-fi, DVD, 6 ���������, �����������";
            ProductDescription2 = "Neoplan SKYLINER N122 3 (75) � 444 ��, ������ �������� �������, 75 ����, ������ �������, DVD, Wi-fi, 6 ���������, �����������";
            ProductDescription3 = "Setra S 431 DT (78) � 007 ��, 78 ����, ������ �������� �������, Wi-fi, DVD, 4 ��������, �����������";
            ProductDescription4 = "Setra S 431 DT (78) � 008 ��, 78 ����, ������ �������� �������, DVD, Wi-fi, 4 ��������, ����������� ";
            ProductDescription5 = "Setra S 431 DT (78) � 111 ��, 78 ����, ������ �������� �������, DVD, Wi-fi, 4 ��������, �����������";
            ProductDescription6 = "������ - ������ (14:00), �����������: 14:00, ��������: 06:30, ���������: 1500�";
            ProductDescription7 = "������ - ������ (14:00), �����������: 14:00, ��������: 06:30, ���������: 1500�";
            ProductDescription8 = "������ - ������ (20:00), �����������: 20:00, ��������: 11:30, ���������: 1500�";
            ProductDescription9 = "������ - ������ (19:00), �����������: 19:00, ��������: 11:30, ���������: 1500�";
            return Page();
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
