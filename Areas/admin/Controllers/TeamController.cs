using Microsoft.AspNetCore.Mvc;

namespace MarialaTemplate.Areas.admin.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
