using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Subjects
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subject Subject { get; set; }

        // Обработка GET-запроса для редактирования предмета
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Subject = await _context.Subjects.FindAsync(id);  // Загружаем предмет по ID

            if (Subject == null)
            {
                return NotFound();  // Если предмет не найден, показываем ошибку
            }

            return Page();
        }

        // Обработка POST-запроса для сохранения изменений
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (ModelState.IsValid)
            {
                _context.Attach(Subject).State = EntityState.Modified;  // Отметка предмета как измененного
                await _context.SaveChangesAsync();  // Сохраняем изменения в базе данных
                return RedirectToPage("/Subjects/Index");  // Перенаправление на страницу списка предметов
            }

            return Page();
        }
    }
}
