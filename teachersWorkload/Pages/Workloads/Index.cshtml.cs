using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Workloads
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Workload> Workloads { get; set; }

        // Обработка GET-запроса для отображения всех нагрузок
        public async Task OnGetAsync()
        {
            Workloads = await _context.Workloads
                .Include(w => w.Teacher)   // Загружаем преподавателя
                .Include(w => w.Subject)    // Загружаем предмет, чтобы получить часы
                .Include(w => w.Group)      // Загружаем группу
                .ToListAsync();             // Загружаем все данные
        }
    }
}
