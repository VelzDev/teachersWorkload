using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Subjects
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subject Subject { get; set; }

        // Обработка GET-запроса для загрузки данных о предмете
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Subject = await _context.Subjects.FindAsync(id);  // Загружаем предмет по ID

            if (Subject == null)
            {
                return NotFound();  // Если предмет не найден, возвращаем ошибку
            }

            return Page();
        }

        // Обработка POST-запроса для удаления предмета
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);  // Находим предмет для удаления

            if (subject != null)
            {
                _context.Subjects.Remove(subject);  // Удаляем предмет
                await _context.SaveChangesAsync();  // Сохраняем изменения
            }

            return RedirectToPage("/Subjects/Index");  // Перенаправляем на страницу списка предметов
        }
    }
}
