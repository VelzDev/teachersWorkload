using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Concrete;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Context;

namespace teachersWorkload.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Subject> Subjects { get; set; }

        // ��������� GET-������� ��� ����������� ���� ���������
        public async Task OnGetAsync()
        {
            Subjects = await _context.Subjects.ToListAsync();  // ��������� ��� �������� �� ���� ������
        }
    }
}
