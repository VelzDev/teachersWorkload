using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Degrees
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Degree Degree { get; set; }

        // ��������� GET-������� ��� �������� ������ � �������
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Degree = await _context.Degrees.FindAsync(id); // ����� ������� �� ID

            if (Degree == null)
            {
                return NotFound(); // ���� ������� �� �������, ���������� ������
            }

            return Page();
        }

        // ��������� POST-������� ��� �������� �������
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var degree = await _context.Degrees.FindAsync(id);

            if (degree != null)
            {
                _context.Degrees.Remove(degree); // �������� ������� �� ���� ������
                await _context.SaveChangesAsync(); // ���������� ���������
            }

            return RedirectToPage("/Degrees/Index"); // ��������������� �� �������� ������ ��������
        }
    }
}
