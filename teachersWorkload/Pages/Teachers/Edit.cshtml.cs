using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Teachers
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Teacher Teacher { get; set; }

        public IEnumerable<Degree> Degrees { get; set; }
        public IEnumerable<Position> Positions { get; set; }

        // ќбработка GET-запроса дл€ редактировани€ преподавател€
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Teacher = await _context.Teachers
                .Include(t => t.Degree)
                .Include(t => t.Position)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (Teacher == null)
            {
                return NotFound();
            }

            Degrees = _context.Degrees.ToList();
            Positions = _context.Positions.ToList();

            return Page();
        }

        // ќбработка POST-запроса дл€ сохранени€ изменений
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (ModelState.IsValid)
            {
                _context.Attach(Teacher).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToPage("/Teachers/Index");
            }

            return Page();
        }
    }
}
