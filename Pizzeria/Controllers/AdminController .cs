using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Data;
using Pizzeria.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System;
using Pizzeria.Data.EntityFrameworkCore;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AdminController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GestisciProdotti()
        {
            var prodotti = _context.Products
                .Include(p => p.Ingredients)
                .ToList();
            return View(prodotti);
        }

        public IActionResult CreaProdotto()
        {
            ViewBag.Ingredients = _context.Products.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreaProdotto(Product product, IFormFile photo, int[] selectedIngredients)
        {
            if (ModelState.IsValid)
            {
                if (photo != null && photo.Length > 0)
                {
                    var filePath = Path.Combine(_env.WebRootPath, "img", photo.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }
                    product.PhotoUrl = "/img/" + photo.FileName;
                }

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GestisciProdotti));
            }
            ViewBag.Ingredients = _context.Products.ToList();
            return View(product);
        }

        public IActionResult ModificaProdotto(int id)
        {
            var prodotto = _context.Products
                .Include(p => p.Ingredients)
                .SingleOrDefault(p => p.Id == id);

            if (prodotto == null)
            {
                return NotFound();
            }

            ViewBag.Ingredients = _context.Products.ToList();
            return View(prodotto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModificaProdotto(int id, Product product, IFormFile photo, int[] selectedIngredients)
        {
            if (ModelState.IsValid)
            {
                var prodottoEsistente = _context.Products
                    .Include(p => p.Ingredients)
                    .SingleOrDefault(p => p.Id == id);

                if (prodottoEsistente == null)
                {
                    return NotFound();
                }

                if (photo != null && photo.Length > 0)
                {
                    var filePath = Path.Combine(_env.WebRootPath, "img", photo.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }
                    prodottoEsistente.PhotoUrl = "/img/" + photo.FileName;
                }

                prodottoEsistente.Name = product.Name;
                prodottoEsistente.Price = product.Price;
                prodottoEsistente.DeliveryTime = product.DeliveryTime;

                

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GestisciProdotti));
            }
            ViewBag.Ingredients = _context.Products.ToList();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminaProdotto(int id)
        {
            var prodotto = await _context.Products
                .Include(p => p.Ingredients)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (prodotto == null)
            {
                return Json(new { success = false, message = "Prodotto non trovato." });
            }

            if (!string.IsNullOrEmpty(prodotto.PhotoUrl))
            {
                var filePath = Path.Combine(_env.WebRootPath, prodotto.PhotoUrl.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            _context.Products.Remove(prodotto);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        public async Task<IActionResult> GestisciOrdini()
        {
            var ordini = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();
            return View(ordini);
        }

        [HttpPost]
        public async Task<IActionResult> AggiornaStatoOrdine(int id)
        {
            var ordine = await _context.Orders.FindAsync(id);
            if (ordine == null)
            {
                return NotFound();
            }

            ordine.IsCompleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(GestisciOrdini));
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetTotaleOrdini(DateTime data)
        {
            var totaleOrdini = await _context.Orders
                .Where(o => o.OrderDate.Date == data.Date && o.IsCompleted)
                .CountAsync();

            return Json(new { totaleOrdini });
        }

        [HttpPost]
        public async Task<IActionResult> GetTotaleRicavi(DateTime data)
        {
            var totaleRicavi = await _context.Orders
                .Where(o => o.OrderDate.Date == data.Date && o.IsCompleted)
                .SelectMany(o => o.OrderItems)
                .SumAsync(oi => oi.Product.Price * oi.Quantity);

            return Json(new { totaleRicavi });
        }
    }
}