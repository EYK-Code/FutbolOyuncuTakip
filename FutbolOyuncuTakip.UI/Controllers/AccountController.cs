using FutbolOyuncuTakip.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FutbolOyuncuTakip.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (model.KullaniciAdi == "admin" && model.Sifre == "admin123")
            {
                return RedirectToAction("Index", "Futbolcu");
            }

            ViewBag.Hata = "Kullanıcı adı veya şifre hatalı";
            return View();
        }
    }
}
