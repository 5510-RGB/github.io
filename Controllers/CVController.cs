using Microsoft.AspNetCore.Mvc;
using PolatPortfolio.Models;
using System.IO;
using System.Text;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace PolatPortfolio.Controllers
{
    public class CVController : Controller
    {
        public IActionResult Index()
        {
            var model = new CVModel
            {
                FullName = "Polat",
                Summary = "Yazılım Mühendisliği 2. sınıf öğrencisi. Web ve yapay zeka ile ilgileniyor.",
                Skills = new[] { "C#", "ASP.NET Core", "HTML", "CSS", "JavaScript" },
                Education = new[] { "X Üniversitesi - Yazılım Mühendisliği (Devam ediyor)" },
                Experience = new[] { "Proje: PolatPortfolio" }
            };
            return View(model);
        }

        public IActionResult DownloadPdf()
        {
            var bytes = GenerateSimplePdfBytes();
            return File(bytes, "application/pdf", "Polat_CV.pdf");
        }

        private byte[] GenerateSimplePdfBytes()
        {
            using var ms = new MemoryStream();
            using (var writer = new PdfWriter(ms))
            {
                using var pdf = new PdfDocument(writer);
                using var doc = new Document(pdf);
                doc.Add(new Paragraph("Polat - CV"));
                doc.Add(new Paragraph("Yazılım Mühendisliği 2. sınıf öğrencisi."));
                doc.Add(new Paragraph("Skills: C#, ASP.NET Core, HTML, CSS, JavaScript"));
            }
            return ms.ToArray();
        }
    }
}
