using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Subjects
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subject Subject { get; set; }

        // ��������� GET-������� ��� �������������� ��������
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Subject = await _context.Subjects.FindAsync(id);  // ��������� ������� �� ID

            if (Subject == null)
            {
                return NotFound();  // ���� ������� �� ������, ���������� ������
            }

            return Page();
        }

        // ��������� POST-������� ��� ���������� ���������
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (ModelState.IsValid)
            {
                _context.Attach(Subject).State = EntityState.Modified;  // ������� �������� ��� �����������
                await _context.SaveChangesAsync();  // ��������� ��������� � ���� ������
                return RedirectToPage("/Subjects/Index");  // ��������������� �� �������� ������ ���������
            }

            return Page();
        }
    }
}
