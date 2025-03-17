using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Subject> Subjects { get; set; }

        // Обработка GET-запроса для отображения всех предметов
        public async Task OnGetAsync()
        {
            Subjects = await _context.Subjects.ToListAsync();  // Загружаем все предметы из базы данных
        }
    }
}
