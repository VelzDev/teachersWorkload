using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Groups
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Group Group { get; set; }

        // Обработка POST-запроса для добавления новой группы
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Groups.Add(Group);  // Добавляем новую группу в контекст
                await _context.SaveChangesAsync();  // Сохраняем изменения в базе данных
                return RedirectToPage("/Groups/Index");  // Перенаправление на страницу списка групп
            }

            return Page();
        }
    }
}
