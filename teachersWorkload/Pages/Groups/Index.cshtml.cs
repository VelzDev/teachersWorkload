using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Groups
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Group> Groups { get; set; }

        // Обработка GET-запроса для отображения всех групп
        public async Task OnGetAsync()
        {
            Groups = await _context.Groups.ToListAsync();  // Загружаем все группы из базы данных
        }
    }
}
