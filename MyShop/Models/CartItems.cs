namespace MyShop.Models
{
    public class CartItems
    {
        public int ProductId { get; set; }
        public string Name { get; set; } // Название товара
        public int Quantity { get; set; } // Количество
        public decimal Price { get; set; } // Цена за единицу
    }
}
