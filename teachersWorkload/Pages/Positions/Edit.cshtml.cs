using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Positions
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Position Position { get; set; }

        // Обработка GET-запроса для редактирования степени
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Position = await _context.Positions.FindAsync(id); // Поиск степени по ID

            if (Position == null)
            {
                return NotFound(); // Если степень не найдена, вернем ошибку
            }

            return Page(); // Если степень найдена, отобразим страницу для редактирования
        }

        // Обработка POST-запроса для сохранения изменений
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (ModelState.IsValid)
            {
                _context.Attach(Position).State = EntityState.Modified; // Отметка объекта как измененного
                await _context.SaveChangesAsync(); // Сохранение изменений
                return RedirectToPage("/Positions/Index"); // Перенаправление на страницу списка должностей
            }

            return Page();
        }
    }
}
