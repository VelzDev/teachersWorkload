using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teachersWorkload.Repository;

namespace teachersWorkload.Pages.Teachers
{
    public class TeacherReportModel : PageModel
    {
        private readonly PdfReportService _pdfReportService;

        public TeacherReportModel(PdfReportService pdfReportService)
        {
            _pdfReportService = pdfReportService;
        }

        public int TeacherId { get; set; }

        // Этот метод будет вызываться, когда пользователь переходит по URL TeacherReport/{teacherId}
        public void OnGet(int teacherId)
        {
            TeacherId = teacherId;
        }

        // Этот метод будет вызываться при отправке формы для скачивания PDF
        public IActionResult OnGetDownload(int teacherId)
        {
            var pdfBytes = _pdfReportService.GenerateTeacherReport(teacherId);
            return File(pdfBytes, "application/pdf", "Teacher_Report.pdf");
        }
    }
}
