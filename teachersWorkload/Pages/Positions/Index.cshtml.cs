using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Positions
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Position> Positions { get; set; }

        // Обработка GET-запроса
        public async Task OnGetAsync()
        {
            Positions = await _context.Positions.ToListAsync(); // Получение всех степеней из базы данных
        }
    }
}
