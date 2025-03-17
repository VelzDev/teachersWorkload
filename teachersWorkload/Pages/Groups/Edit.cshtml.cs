using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Context;
using teachersWorkload.Concrete;

namespace teachersWorkload.Pages.Groups
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Group Group { get; set; }

        // Обработка GET-запроса для редактирования группы
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Group = await _context.Groups.FindAsync(id);  // Загружаем группу по ID

            if (Group == null)
            {
                return NotFound();  // Если группа не найдена, показываем ошибку
            }

            return Page();
        }

        // Обработка POST-запроса для сохранения изменений
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (ModelState.IsValid)
            {
                _context.Attach(Group).State = EntityState.Modified;  // Отметка группы как измененной
                await _context.SaveChangesAsync();  // Сохранение изменений в базе данных
                return RedirectToPage("/Groups/Index");  // Перенаправление на страницу списка групп
            }

            return Page();
        }
    }
}
