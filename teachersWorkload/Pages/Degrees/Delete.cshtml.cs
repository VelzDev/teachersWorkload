using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Degrees
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Degree Degree { get; set; }

        // Обработка GET-запроса для загрузки данных о степени
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Degree = await _context.Degrees.FindAsync(id); // Поиск степени по ID

            if (Degree == null)
            {
                return NotFound(); // Если степень не найдена, возвращаем ошибку
            }

            return Page();
        }

        // Обработка POST-запроса для удаления степени
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var degree = await _context.Degrees.FindAsync(id);

            if (degree != null)
            {
                _context.Degrees.Remove(degree); // Удаление степени из базы данных
                await _context.SaveChangesAsync(); // Сохранение изменений
            }

            return RedirectToPage("/Degrees/Index"); // Перенаправление на страницу списка степеней
        }
    }
}
