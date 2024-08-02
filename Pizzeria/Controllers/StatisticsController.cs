using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Assicurati di avere questa direttiva
using Pizzeria.Models;
using System.Diagnostics;

namespace Pizzeria.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly ILogger<StatisticsController> _logger;

        public StatisticsController(ILogger<StatisticsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
