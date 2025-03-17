using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Context;
using teachersWorkload.Concrete;

namespace teachersWorkload.Pages.Groups
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Group Group { get; set; }

        // Обработка GET-запроса для загрузки данных о группе
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Group = await _context.Groups.FindAsync(id);  // Загружаем группу по ID

            if (Group == null)
            {
                return NotFound();  // Если группа не найдена, возвращаем ошибку
            }

            return Page();
        }

        // Обработка POST-запроса для удаления группы
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);  // Находим группу для удаления

            if (group != null)
            {
                _context.Groups.Remove(group);  // Удаляем группу
                await _context.SaveChangesAsync();  // Сохраняем изменения
            }

            return RedirectToPage("/Groups/Index");  // Перенаправляем на страницу списка групп
        }
    }
}
