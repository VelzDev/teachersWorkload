using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Subjects
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subject Subject { get; set; }

        // ��������� GET-������� ��� �������� ������ � ��������
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Subject = await _context.Subjects.FindAsync(id);  // ��������� ������� �� ID

            if (Subject == null)
            {
                return NotFound();  // ���� ������� �� ������, ���������� ������
            }

            return Page();
        }

        // ��������� POST-������� ��� �������� ��������
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);  // ������� ������� ��� ��������

            if (subject != null)
            {
                _context.Subjects.Remove(subject);  // ������� �������
                await _context.SaveChangesAsync();  // ��������� ���������
            }

            return RedirectToPage("/Subjects/Index");  // �������������� �� �������� ������ ���������
        }
    }
}
