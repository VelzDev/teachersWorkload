using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Teachers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Teacher> Teachers { get; set; }

        // ќбработка GET-запроса дл€ отображени€ всех преподавателей
        public async Task OnGetAsync()
        {
            Teachers = await _context.Teachers
                .Include(t => t.Degree)    // «агружаем св€занные данные о степени
                .Include(t => t.Position)  // «агружаем св€занные данные о должности
                .ToListAsync();           // ѕолучаем список всех преподавателей
        }
    }
}
