using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SandboxCore11.Data;
using SandboxCore11.Models.HomeViewModels;

namespace SandboxCore11.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices]ApplicationDbContext db)
        {
            var orders = new List<PurchaseOrder>()
            {
                new PurchaseOrder() { Name = "Donec id elit non", LastUpdated = DateTime.Now.AddDays(-2), Description = "Maecenas sed diam eget risus varius blandit. Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit. Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit." },
                new PurchaseOrder() { Name = "Maecenas sed diam eget risus", LastUpdated = DateTime.Now.AddDays(-3), Description = "Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit. Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit." },
                new PurchaseOrder() { Name = "Maecenas sed diam eget risus", LastUpdated = DateTime.Now.AddDays(-8), Description = "Maecenas sed diam eget risus varius blandit. Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit." },
                new PurchaseOrder() { Name = "Donec id elit non", LastUpdated = DateTime.Now.AddDays(-2), Description = "Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit. Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit." },
                new PurchaseOrder() { Name = "Maecenas sed diam eget risus", LastUpdated = DateTime.Now.AddDays(-5), Description = "Maecenas sed diam eget risus varius blandit. Maecenas sed diam eget risus varius blandit. Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit." },
                new PurchaseOrder() { Name = "Donec id elit non", LastUpdated = DateTime.Now.AddDays(-15), Description = "Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit." }
            };

            var vm = new IndexViewModel()
            {
                Orders = orders
            };

            return View(vm);
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
