namespace SandboxCore11.Features.Home
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using SandboxCore11.Data;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult WhoAmI()
        {
            return View();
        }
    }
}
