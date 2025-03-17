using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Subjects
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subject Subject { get; set; }

        // Обработка POST-запроса для добавления нового предмета
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Subjects.Add(Subject);  // Добавляем новый предмет в контекст
                await _context.SaveChangesAsync();  // Сохраняем изменения в базе данных
                return RedirectToPage("/Subjects/Index");  // Перенаправление на страницу списка предметов
            }

            return Page();
        }
    }
}
