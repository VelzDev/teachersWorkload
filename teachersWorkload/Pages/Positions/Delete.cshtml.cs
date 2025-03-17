using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Positions
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Position Position { get; set; }

        // Обработка GET-запроса для загрузки данных о степени
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Position = await _context.Positions.FindAsync(id); // Поиск степени по ID

            if (Position == null)
            {
                return NotFound(); // Если степень не найдена, возвращаем ошибку
            }

            return Page();
        }

        // Обработка POST-запроса для удаления степени
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var pos = await _context.Positions.FindAsync(id);

            if (pos != null)
            {
                _context.Positions.Remove(pos); // Удаление степени из базы данных
                await _context.SaveChangesAsync(); // Сохранение изменений
            }

            return RedirectToPage("/Degrees/Index"); // Перенаправление на страницу списка степеней
        }
    }
}
