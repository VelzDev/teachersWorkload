using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Positions
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Position Position { get; set; }

        // ��������� GET-������� ��� �������������� �������
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Position = await _context.Positions.FindAsync(id); // ����� ������� �� ID

            if (Position == null)
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
                _context.Attach(Position).State = EntityState.Modified; // ������� ������� ��� �����������
                await _context.SaveChangesAsync(); // ���������� ���������
                return RedirectToPage("/Positions/Index"); // ��������������� �� �������� ������ ����������
            }

            return Page();
        }
    }
}
