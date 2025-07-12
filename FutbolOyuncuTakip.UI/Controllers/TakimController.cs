using FutbolOyuncuTakip.UI.Context;
using FutbolOyuncuTakip.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FutbolOyuncuTakip.UI.Controllers
{
    public class TakimController : Controller
    {
        private readonly MyDbContext _context;

        public TakimController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var takimlar = _context.Takim.Include(t => t.Lig).ToList();
            return View(takimlar);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Ligler = _context.Lig.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Takim takim)
        {
            _context.Takim.Add(takim);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var takim = _context.Takim.Find(id);
            if (takim == null)
            {
                return NotFound();
            }

            ViewBag.Ligler = _context.Lig.ToList();
            return View(takim);
        }

        [HttpPost]
        public IActionResult Edit(Takim takim)
        {
            _context.Takim.Update(takim);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var takim = _context.Takim.Find(id);
            if (takim != null)
            {
                _context.Takim.Remove(takim);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}