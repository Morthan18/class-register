using Microsoft.AspNetCore.Mvc;
using school_management.Data;
using school_management.Models;
using System.Diagnostics;

namespace school_management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly school_managementContext _context;

        public HomeController(ILogger<HomeController> logger, school_managementContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
/*            News news = new News {Title="Super tytuł",  Content="super content", CreatedDate=new DateTime()} ;
            await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();*/
            return View(_context.News.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}