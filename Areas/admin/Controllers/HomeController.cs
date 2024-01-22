﻿using Microsoft.AspNetCore.Mvc;

namespace MarialaTemplate.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
