using FutbolOyuncuTakip.UI.Context;
using FutbolOyuncuTakip.UI.Filters;
using FutbolOyuncuTakip.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FutbolOyuncuTakip.UI.Controllers
{
    public class LigController : Controller
    {
        private readonly MyDbContext _context;

        public LigController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ligler = _context.Lig
                .Include(l => l.Takimlar)
                .ToList();
            return View(ligler);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateUniqueLigAd]
        public IActionResult Create(Lig lig)
        {
            _context.Lig.Add(lig);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var lig = _context.Lig.Find(id);
            if (lig == null)
            {
                return NotFound();
            }
            return View(lig);
        }

        [HttpPost]
        public IActionResult Edit(Lig lig)
        {
            _context.Lig.Update(lig);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var lig = _context.Lig.Find(id);
            if (lig != null)
            {
                _context.Lig.Remove(lig);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
