using Microsoft.AspNetCore.Mvc;
using PolatPortfolio.Models;
using System.Collections.Generic;

namespace PolatPortfolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Cv()
        {
            var model = new CVModel
            {
                FullName = "Polat",
                Summary = "Yazılım Mühendisliği 2. sınıf öğrencisi. Web ve yapay zeka ile ilgileniyor.",
                Skills = new[] { "C#", "ASP.NET Core", "HTML", "CSS", "JavaScript" },
                Education = new[] { "X Üniversitesi - Yazılım Mühendisliği (Devam ediyor)" },
                Experience = new[] { "Örnek proje: Portfolyo web uygulaması" }
            };
            return View(model);
        }
    }
}
