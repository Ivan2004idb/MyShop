namespace MyShop.Models
{
    public class SearchKeyword
    {
        public int Id { get; set; } // Уникальный идентификатор
        public string Keyword { get; set; } // Ключевое слово
        public string PagePath { get; set; } // Путь к странице
    }

}
