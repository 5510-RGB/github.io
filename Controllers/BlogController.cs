using Microsoft.AspNetCore.Mvc;
using PolatPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PolatPortfolio.Controllers
{
    public class BlogController : Controller
    {
        private static readonly List<BlogPost> _posts = new List<BlogPost>
        {
            new BlogPost { Id=1, Title="İlk Blog Yazım", Content="ASP.NET Core MVC ile web sitemi yaptım!", Date=DateTime.Now},
            new BlogPost { Id=2, Title="Neden Yazılım?", Content="Yazılım mühendisliğine giriş hikayem...", Date=DateTime.Now.AddDays(-10)}
        };

        public IActionResult Index()
        {
            return View(_posts.OrderByDescending(p => p.Date).ToList());
        }

        public IActionResult Details(int id)
        {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound();
            return View(post);
        }
    }
}
