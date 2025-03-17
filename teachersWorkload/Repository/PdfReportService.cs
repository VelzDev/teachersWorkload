using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using System.Text;
using Microsoft.EntityFrameworkCore;
using teachersWorkload.Context;
namespace teachersWorkload.Repository
{
    public class PdfReportService
{
    private readonly ApplicationDbContext _context;

    public PdfReportService(ApplicationDbContext context)
    {
        _context = context;
    }

    public byte[] GenerateTeacherReport(int teacherId)
    {
        // Получаем данные преподавателя
        var teacher = _context.Teachers
            .Include(t => t.Degree)
            .Include(t => t.Position)
            .FirstOrDefault(t => t.Id == teacherId);

        if (teacher == null)
            throw new Exception("Преподаватель не найден.");

        // Получаем нагрузки
        var workloads = _context.Workloads
            .Include(w => w.Subject)
            .Include(w => w.Group)
            .Where(w => w.TeacherId == teacherId)
            .ToList();

        // Создаем PDF
        using (var document = new PdfDocument())
        {
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("Arial", 12);

            int yPosition = 20;

            // Заполняем основные данные о преподавателе
            gfx.DrawString("Отчет по преподавателю", new XFont("Arial", 14, XFontStyle.Bold), XBrushes.Black, 20, yPosition);
            yPosition += 30;

            gfx.DrawString($"ФИО: {teacher.LastName} {teacher.FirstName} {teacher.Patronymic}", font, XBrushes.Black, 20, yPosition);
            yPosition += 20;

            gfx.DrawString($"Ученая степень: {teacher.Degree.Name}", font, XBrushes.Black, 20, yPosition);
            yPosition += 20;

            gfx.DrawString($"Должность: {teacher.Position.Name}", font, XBrushes.Black, 20, yPosition);
            yPosition += 20;

            // Нагрузка в часах
            var totalLectureHours = workloads.Sum(w => w.Subject.LectureHours);
            var totalPracticalHours = workloads.Sum(w => w.Subject.PracticalHours);

            gfx.DrawString($"Общая нагрузка (часов): {totalLectureHours + totalPracticalHours}", font, XBrushes.Black, 20, yPosition);
            yPosition += 20;

            gfx.DrawString($"Лекционные часы: {totalLectureHours}", font, XBrushes.Black, 20, yPosition);
            yPosition += 20;

            gfx.DrawString($"Практические часы: {totalPracticalHours}", font, XBrushes.Black, 20, yPosition);
            yPosition += 30;

            // Нагрузка по группам
            gfx.DrawString("Нагрузка по группам:", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, 20, yPosition);
            yPosition += 20;

            // Создаем таблицу для групп
            foreach (var group in workloads.Select(w => w.Group).Distinct())
            {
                var groupLectureHours = workloads.Where(w => w.GroupId == group.Id).Sum(w => w.Subject.LectureHours);
                var groupPracticalHours = workloads.Where(w => w.GroupId == group.Id).Sum(w => w.Subject.PracticalHours);

                gfx.DrawString($"{group.GroupNumber} | {groupLectureHours} часов лекций | {groupPracticalHours} часов практики", font, XBrushes.Black, 20, yPosition);
                yPosition += 20;
            }

            yPosition += 20;

            // Нагрузка по предметам
            gfx.DrawString("Нагрузка по предметам:", new XFont("Arial", 12, XFontStyle.Bold), XBrushes.Black, 20, yPosition);
            yPosition += 20;

            // Создаем таблицу для предметов
            foreach (var subject in workloads.Select(w => w.Subject).Distinct())
            {
                var subjectLectureHours = workloads.Where(w => w.SubjectId == subject.Id).Sum(w => w.Subject.LectureHours);
                var subjectPracticalHours = workloads.Where(w => w.SubjectId == subject.Id).Sum(w => w.Subject.PracticalHours);

                gfx.DrawString($"{subject.Name} | {subjectLectureHours} часов лекций | {subjectPracticalHours} часов практик", font, XBrushes.Black, 20, yPosition);
                yPosition += 20;
            }

            // Генерируем PDF в байтовый массив
            using (var stream = new MemoryStream())
            {
                document.Save(stream, false);
                return stream.ToArray();
            }
        }
    }
}
}
