using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Context;
using teachersWorkload.Concrete;

namespace teachersWorkload.Pages.Groups
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Group Group { get; set; }

        // ��������� GET-������� ��� �������� ������ � ������
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Group = await _context.Groups.FindAsync(id);  // ��������� ������ �� ID

            if (Group == null)
            {
                return NotFound();  // ���� ������ �� �������, ���������� ������
            }

            return Page();
        }

        // ��������� POST-������� ��� �������� ������
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);  // ������� ������ ��� ��������

            if (group != null)
            {
                _context.Groups.Remove(group);  // ������� ������
                await _context.SaveChangesAsync();  // ��������� ���������
            }

            return RedirectToPage("/Groups/Index");  // �������������� �� �������� ������ �����
        }
    }
}
