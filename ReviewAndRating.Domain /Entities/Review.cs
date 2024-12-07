namespace ReviewAndRating.Domain.Entities;


public class Review
    {
        public Guid Id { get; set; } // Унікальний ідентифікатор відгуку
        public Guid ProductId { get; set; } // ID товару, до якого стосується відгук
        public Guid UserId { get; set; } // ID користувача, який залишив відгук
        public string Comment { get; set; } // Текст відгуку
        public int Rating { get; set; } // Оцінка (наприклад, від 1 до 5)
        public DateTime CreatedAt { get; set; } // Дата створення відгуку
        public DateTime? UpdatedAt { get; set; }
    }
