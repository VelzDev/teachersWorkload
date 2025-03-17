using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Groups
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Group Group { get; set; }

        // ��������� POST-������� ��� ���������� ����� ������
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Groups.Add(Group);  // ��������� ����� ������ � ��������
                await _context.SaveChangesAsync();  // ��������� ��������� � ���� ������
                return RedirectToPage("/Groups/Index");  // ��������������� �� �������� ������ �����
            }

            return Page();
        }
    }
}
