using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Positions
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Position Position { get; set; }

        // ќбработка POST-запроса дл€ создани€ новой степени
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Positions.Add(Position); // ƒобавление новой степени в контекст базы данных
                await _context.SaveChangesAsync(); // —охранение изменений
                return RedirectToPage("/Positions/Index"); // ѕеренаправление на страницу списка степеней
            }
            return Page(); // ≈сли модель невалидна, вернемс€ на текущую страницу
        }
    }
}
