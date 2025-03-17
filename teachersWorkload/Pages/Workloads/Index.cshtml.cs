using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Concrete;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Workloads
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Workload> Workloads { get; set; }

        // ��������� GET-������� ��� ����������� ���� ��������
        public async Task OnGetAsync()
        {
            Workloads = await _context.Workloads
                .Include(w => w.Teacher)   // ��������� �������������
                .Include(w => w.Subject)    // ��������� �������, ����� �������� ����
                .Include(w => w.Group)      // ��������� ������
                .ToListAsync();             // ��������� ��� ������
        }
    }
}
