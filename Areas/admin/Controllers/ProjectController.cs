using MarialaTemplate.DAL;
using MarialaTemplate.Models;
using MarialaTemplate.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarialaTemplate.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProjectController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var project = _context.Projects.ToList();
            return View(project);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProjectCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var isExisted = await _context.Projects.AnyAsync(x => x.Name.ToLower().Contains(vm.Name.ToLower()));
            if (!isExisted)
            {
                ModelState.AddModelError("Name", "Bu adda project movuddur");
            }
            if (vm.Image.ContentType.Contains("image"))
            {
                ModelState.AddModelError("image", "Tip yanlishdir");
            }
            if (vm.Image.Length < 4 * 1024 * 1024)
            {
                ModelState.AddModelError("image", "Uzunlugu sehvdir");
            }
            string filename = Guid.NewGuid() + vm.Image.FileName;
            string path = Path.Combine(_env.WebRootPath, "assets", "images", filename);
            
            using (FileStream stream = new(path, FileMode.Create))
            {
                await vm.Image.CopyToAsync(stream);
            }
            Project project = new()
            {
                Name = vm.Name,
                Description = vm.Description,
                ImageUrl = filename
            };

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0)
            {
                return View();
            }
            var existed = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (existed == null) return NotFound();
            ProjectUpdateVM vm = new()
            {
                Id = existed.Id,
                Name = existed.Name,
                Description = existed.Description,
                ImageUrl = existed.ImageUrl,

            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProjectUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var existed = await _context.Projects.FirstOrDefaultAsync(x => x.Id == vm.Id);
            if (existed == null) return NotFound();
            var isExisted = await _context.Projects.AnyAsync(x => x.Name.ToLower().Contains(vm.Name.ToLower()) && vm.Id != x.Id);
            if (isExisted)
            {
                ModelState.AddModelError("Name", "Bu name movcuddur");
            }
            if (vm.Image != null)
            {
                string filename = Guid.NewGuid() + "/" + vm.Image.FileName;
                string path = Path.Combine(_env.WebRootPath, "assets", "images");
                if (System.IO.File.Exists(path + "/" + existed.ImageUrl))
                {
                    System.IO.File.Delete(path + "/" + existed.ImageUrl);
                }
                using (FileStream stream = new(path + "/" + filename, FileMode.Create))
                {
                 await vm.Image.CopyToAsync(stream);
                }
                existed.ImageUrl = filename;
            }
            existed.Id = vm.Id;
            existed.Name = vm.Name;
            existed.Description = vm.Description;

            _context.Projects.Update(existed);
            await _context.SaveChangesAsync();  
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();
            var existed= await _context.Projects.FirstOrDefaultAsync(x=> x.Id == id);
            if (existed != null) return  NotFound();
            string path = Path.Combine(_env.WebRootPath, "assets","images", existed.ImageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO .File.Delete(path);
            }

            _context.Projects.Remove(existed);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
