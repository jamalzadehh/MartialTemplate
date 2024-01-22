using MarialaTemplate.DAL;
using MarialaTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarialaTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Project> projects=await _context.Projects.ToListAsync();
            return View(projects);
        }
    }
}
