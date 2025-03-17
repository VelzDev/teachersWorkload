using System.ComponentModel.DataAnnotations;

namespace teachersWorkload.Concrete
{
    public class Group
    {
        public int Id { get; set; }  // Уникальный идентификатор группы
        [Required]
        public string? GroupNumber { get; set; }// Номер группы
    }
}
