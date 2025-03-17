using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Degrees
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Degree Degree { get; set; }

        // ��������� GET-������� ��� �������������� �������
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Degree = await _context.Degrees.FindAsync(id); // ����� ������� �� ID

            if (Degree == null)
            {
                return NotFound(); // ���� ������� �� �������, ������ ������
            }

            return Page(); // ���� ������� �������, ��������� �������� ��� ��������������
        }

        // ��������� POST-������� ��� ���������� ���������
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (ModelState.IsValid)
            {
                _context.Attach(Degree).State = EntityState.Modified; // ������� ������� ��� �����������
                await _context.SaveChangesAsync(); // ���������� ���������
                return RedirectToPage("/Degrees/Index"); // ��������������� �� �������� ������ ��������
            }

            return Page();
        }
    }
}
