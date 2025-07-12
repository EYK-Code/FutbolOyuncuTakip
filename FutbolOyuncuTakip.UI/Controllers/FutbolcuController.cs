using FutbolOyuncuTakip.UI.Context;
using FutbolOyuncuTakip.UI.Filters;
using FutbolOyuncuTakip.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FutbolOyuncuTakip.UI.Controllers
{
    public class FutbolcuController : Controller
    {
        private readonly MyDbContext _context;

        public FutbolcuController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var futbolcular = _context.Futbolcu.Include(f => f.Takim).ToList();
            return View(futbolcular);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Takimlar = _context.Takim.ToList();
            return View();
        }

        [HttpPost]
        [NotifyAfterFutbolcu]
        public IActionResult Create(Futbolcu futbolcu)
        {
            // TakimId'nin geçerli olup olmadığını kontrol et
            var takimVarMi = _context.Takim.Any(t => t.Id == futbolcu.TakimId);
            if (!takimVarMi)
            {
                ModelState.AddModelError("TakimId", "Seçilen takım bulunamadı.");
                ViewBag.Takimlar = _context.Takim.ToList();
                return View(futbolcu);
            }

            _context.Futbolcu.Add(futbolcu);
            _context.SaveChanges();

            HttpContext.Items["yeniFutbolcu"] = futbolcu;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var futbolcu = _context.Futbolcu.Find(id);
            if (futbolcu == null)
            {
                return NotFound();
            }

            ViewBag.Takimlar = _context.Takim.ToList();
            return View(futbolcu);
        }

        [HttpPost]
        public IActionResult Edit(Futbolcu futbolcu)
        {
            _context.Futbolcu.Update(futbolcu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var futbolcu = _context.Futbolcu.Find(id);
            if (futbolcu != null)
            {
                _context.Futbolcu.Remove(futbolcu);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
