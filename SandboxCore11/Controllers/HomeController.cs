﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SandboxCore11.Data;

namespace SandboxCore11.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices]ApplicationDbContext db)
        {
            var projects = db.Projects.ToList();
            return View(projects);
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
    }
}