using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Positions
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Position Position { get; set; }

        // ��������� GET-������� ��� �������� ������ � �������
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Position = await _context.Positions.FindAsync(id); // ����� ������� �� ID

            if (Position == null)
            {
                return NotFound(); // ���� ������� �� �������, ���������� ������
            }

            return Page();
        }

        // ��������� POST-������� ��� �������� �������
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var pos = await _context.Positions.FindAsync(id);

            if (pos != null)
            {
                _context.Positions.Remove(pos); // �������� ������� �� ���� ������
                await _context.SaveChangesAsync(); // ���������� ���������
            }

            return RedirectToPage("/Degrees/Index"); // ��������������� �� �������� ������ ��������
        }
    }
}
