using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Context;
using teachersWorkload.Concrete;

namespace teachersWorkload.Pages.Groups
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Group Group { get; set; }

        // ��������� GET-������� ��� �������������� ������
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Group = await _context.Groups.FindAsync(id);  // ��������� ������ �� ID

            if (Group == null)
            {
                return NotFound();  // ���� ������ �� �������, ���������� ������
            }

            return Page();
        }

        // ��������� POST-������� ��� ���������� ���������
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (ModelState.IsValid)
            {
                _context.Attach(Group).State = EntityState.Modified;  // ������� ������ ��� ����������
                await _context.SaveChangesAsync();  // ���������� ��������� � ���� ������
                return RedirectToPage("/Groups/Index");  // ��������������� �� �������� ������ �����
            }

            return Page();
        }
    }
}
