using MyShop.Models;
using System.Text.Json;

namespace MyShop.Utils
{
    public class CartHelper
    {
        private const string CartSessionKey = "Cart";

        // Получение корзины из сессии
        public static List<CartItems> GetCart(ISession session)
        {
            var cartJson = session.GetString(CartSessionKey);
            return cartJson != null ? JsonSerializer.Deserialize<List<CartItems>>(cartJson) : new List<CartItems>();
        }

        // Сохранение корзины в сессию
        public static void SaveCart(ISession session, List<CartItems> cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);
            session.SetString(CartSessionKey, cartJson);
        }

        // Добавление товара в корзину
        public static void AddToCart(ISession session, CartItems item)
        {
            var cart = GetCart(session);
            var existingItem = cart.Find(i => i.ProductId == item.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity; // Увеличиваем количество
            }
            else
            {
                cart.Add(item); // Добавляем новый товар
            }

            SaveCart(session, cart);
        }
        public static void ClearCart(ISession session)
        {
            // Удаляем корзину из сессии
            session.Remove(CartSessionKey);
        }
        public static void UpdateQuantity(ISession session, int productId, int change)
        {
            var cart = GetCart(session);
            var item = cart.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                item.Quantity += change;

                // Удаляем товар, если количество <= 0
                if (item.Quantity <= 0)
                {
                    cart.Remove(item);
                }
            }

            SaveCart(session, cart);
        }

        // Удаление товара из корзины
        public static void RemoveItem(ISession session, int productId)
        {
            var cart = GetCart(session);
            var item = cart.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                cart.Remove(item);
            }

            SaveCart(session, cart);
        }
    }
}
