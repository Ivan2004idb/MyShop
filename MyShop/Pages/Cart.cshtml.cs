using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Models;
using MyShop.Utils;

namespace MyShop.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItems> Cart { get; set; }

        public void OnGet()
        {
            Cart = CartHelper.GetCart(HttpContext.Session);
        }
    }
}
