using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Positions
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Position Position { get; set; }

        // ��������� POST-������� ��� �������� ����� �������
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Positions.Add(Position); // ���������� ����� ������� � �������� ���� ������
                await _context.SaveChangesAsync(); // ���������� ���������
                return RedirectToPage("/Positions/Index"); // ��������������� �� �������� ������ ��������
            }
            return Page(); // ���� ������ ���������, �������� �� ������� ��������
        }
    }
}
