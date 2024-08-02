using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;
using System.Diagnostics;

namespace Pizzeria.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            // Logica per recuperare il menu
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Contact()
        {
            // Logica per la pagina dei contatti
            return View();
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
