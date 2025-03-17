using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Degrees
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Degree> Degrees { get; set; }

        // Обработка GET-запроса
        public async Task OnGetAsync()
        {
            Degrees = await _context.Degrees.ToListAsync(); // Получение всех степеней из базы данных
        }
    }
}
