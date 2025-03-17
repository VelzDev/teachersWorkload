using System.ComponentModel.DataAnnotations;

namespace teachersWorkload.Concrete
{
    public class Subject
    {
        public int Id { get; set; }  // Уникальный идентификатор
        [Required]
        public string? Name { get; set; } // Название предмета
        [Required]
        public int LectureHours { get; set; }  // Количество лекционных часов
        [Required]
        public int PracticalHours { get; set; }  // Количество практических часов
    }
}
