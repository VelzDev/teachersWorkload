using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Workloads
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Workload Workload { get; set; }

        // ќбработка GET-запроса дл€ загрузки данных о нагрузке
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Workload = await _context.Workloads
                .Include(w => w.Teacher)
                .Include(w => w.Subject)
                .Include(w => w.Group)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (Workload == null)
            {
                return NotFound();
            }

            return Page();
        }

        // ќбработка POST-запроса дл€ удалени€ нагрузки
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var workload = await _context.Workloads.FindAsync(id);

            if (workload != null)
            {
                _context.Workloads.Remove(workload);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Workloads/Index");
        }
    }
}
