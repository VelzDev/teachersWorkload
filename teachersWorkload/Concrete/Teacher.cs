using System.ComponentModel.DataAnnotations;

namespace teachersWorkload.Concrete
{
    public class Teacher
    {
        public int Id { get; set; }  // Уникальный идентификатор
        [Required]
        public string? LastName { get; set; } // Фамилия
        [Required]
        public string? FirstName { get; set; } // Имя
        [Required]
        public string? Patronymic { get; set; } // Отчество
        [Required]
        public int DegreeId { get; set; } // Ученая степень
        public Degree Degree { get; set; }
        [Required]
        public int PositionId { get; set; } // Должность
        public Position Position { get; set; }
        [Required]
        public int Experience { get; set; }  // Стаж работы
    }
}
