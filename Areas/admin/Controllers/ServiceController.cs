using Microsoft.AspNetCore.Mvc;

namespace MarialaTemplate.Areas.admin.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
