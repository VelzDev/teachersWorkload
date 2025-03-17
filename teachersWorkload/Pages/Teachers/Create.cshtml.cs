using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Teachers
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Teacher Teacher { get; set; }

        public IEnumerable<Degree> Degrees { get; set; }
        public IEnumerable<Position> Positions { get; set; }

        // Обработка GET-запроса для отображения формы
        public void OnGet()
        {
            Degrees = _context.Degrees.ToList();
            Positions = _context.Positions.ToList();
        }

        // Обработка POST-запроса для добавления нового преподавателя
        public async Task<IActionResult> OnPostAsync()
        {
            // Загружаем Degree и Position по их ID
                var degree = await _context.Degrees.FindAsync(Teacher.DegreeId);
                var position = await _context.Positions.FindAsync(Teacher.PositionId);

                if (degree == null || position == null)
                {
                    // Если степень или должность не найдены, добавляем ошибку
                    ModelState.AddModelError(string.Empty, "Invalid degree or position.");
                    return Page();
                }

                // Присваиваем объекты Degree и Position в Teacher
                Teacher.Degree = degree;
                Teacher.Position = position;
            if (Teacher.FirstName != null && Teacher.LastName != null && Teacher.Patronymic != null && Teacher.Experience != 0)
            {
                // Добавляем преподавателя в базу данных
                _context.Teachers.Add(Teacher);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Teachers/Index");
            }
            return Page();
        }
    }
}
