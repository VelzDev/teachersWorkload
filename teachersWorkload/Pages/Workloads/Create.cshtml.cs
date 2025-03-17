using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Workloads
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Workload Workload { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Group> Groups { get; set; }

        // ќбработка GET-запроса дл€ отображени€ формы
        public void OnGet()
        {
            Teachers = _context.Teachers.ToList();
            Subjects = _context.Subjects.ToList();
            Groups = _context.Groups.ToList();
        }

        // ќбработка POST-запроса дл€ добавлени€ новой нагрузки
        public async Task<IActionResult> OnPostAsync()
        {
            var teacher = await _context.Teachers.FindAsync(Workload.TeacherId);
            var degree = await _context.Degrees.FindAsync(teacher.DegreeId);
            var position = await _context.Positions.FindAsync(teacher.PositionId);
            teacher.Degree = degree;
            teacher.Position = position;
            var subject = await _context.Subjects.FindAsync(Workload.SubjectId);
            var group = await _context.Groups.FindAsync(Workload.GroupId);
            Workload.Teacher = teacher;
            Workload.Subject = subject;
            Workload.Group = group;
            Workload.Year = DateTime.Now.Year;
            if (Workload.TeacherId != 0 && Workload.GroupId != 0 && Workload.SubjectId != 0)
            {
                _context.Workloads.Add(Workload);  // ƒобавл€ем новую нагрузку в контекст
                await _context.SaveChangesAsync();  // —охран€ем изменени€ в базе данных
                return RedirectToPage("/Workloads/Index");  // ѕеренаправление на страницу списка нагрузок
            }

            return Page();
        }
    }
}
