namespace MyShop.Models
{
    public class Feedback
    {
        public int Id { get; set; }           // Первичный ключ
        public string Name { get; set; }      // Имя пользователя
        public string Comment { get; set; }   // Текст отзыва
        public string Rating { get; set; }    // Рейтинг (excellent/good/average)
        public bool Subscribe { get; set; }   // Подписка на новости
        public string Suggestions { get; set; }// Предложения
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Время создания
    }
}
