using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Workloads
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Workload Workload { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Group> Groups { get; set; }

        // ��������� GET-������� ��� �������������� ��������
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Workload = await _context.Workloads
                .Include(w => w.Teacher)
                .Include(w => w.Subject)
                .Include(w => w.Group)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (Workload == null)
            {
                return NotFound();
            }

            Teachers = _context.Teachers.ToList();
            Subjects = _context.Subjects.ToList();
            Groups = _context.Groups.ToList();

            return Page();
        }

        // ��������� POST-������� ��� ���������� ���������
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (ModelState.IsValid)
            {
                _context.Attach(Workload).State = EntityState.Modified;  // ������� �������� ��� ����������
                await _context.SaveChangesAsync();  // ��������� ��������� � ���� ������
                return RedirectToPage("/Workloads/Index");  // ��������������� �� �������� ������ ��������
            }

            return Page();
        }
    }
}
