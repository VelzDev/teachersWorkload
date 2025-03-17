using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Subjects
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subject Subject { get; set; }

        // ��������� POST-������� ��� ���������� ������ ��������
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Subjects.Add(Subject);  // ��������� ����� ������� � ��������
                await _context.SaveChangesAsync();  // ��������� ��������� � ���� ������
                return RedirectToPage("/Subjects/Index");  // ��������������� �� �������� ������ ���������
            }

            return Page();
        }
    }
}
