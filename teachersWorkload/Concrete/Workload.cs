namespace teachersWorkload.Concrete
{
    public class Workload
    {
        public int Id { get; set; }  // Уникальный идентификатор
        public int TeacherId { get; set; }  // Преподаватель
        public Teacher Teacher { get; set; }  // Связь с преподавателем
        public int SubjectId { get; set; }  // Предмет
        public Subject Subject { get; set; }  // Связь с предметом
        public int GroupId { get; set; }  // Группа
        public Group Group { get; set; }  // Связь с группой
        public int Year { get; set; }  // Год учебного года
    }
}
