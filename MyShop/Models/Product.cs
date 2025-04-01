namespace MyShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }    // Категория
        public string Name { get; set; }        // Название товара
        public decimal Price { get; set; }      // Цена
        public string ImagePath { get; set; }   // Путь к изображению (например, "product1.png")
        public string DescriptionPage { get; set; } // Ссылка на страницу с подробным описанием (напр. "product1.htm")
    }
}
