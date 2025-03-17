using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Degrees
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Degree Degree { get; set; }

        // ��������� POST-������� ��� �������� ����� �������
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Degrees.Add(Degree); // ���������� ����� ������� � �������� ���� ������
                await _context.SaveChangesAsync(); // ���������� ���������
                return RedirectToPage("/Degrees/Index"); // ��������������� �� �������� ������ ��������
            }
            return Page(); // ���� ������ ���������, �������� �� ������� ��������
        }
    }
}
