using Microsoft.AspNetCore.Mvc;
using TatliTarifleri.Data;
using TatliTarifleri.Models;

namespace TatliTarifleri.Controllers
{
    public class HesapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HesapController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> KullaniciGirisYap(Kullanicilar User)
        {
            var LoginUser = _context.Kullanicilar.FirstOrDefault(u => u.EPosta == User.EPosta && u.Sifre == User.Sifre);
            if (LoginUser != null)
            {
                HttpContext.Session.SetInt32("UserID", LoginUser.Id);
                HttpContext.Session.SetString("User", LoginUser.Ad);
            }
            else
            {
                TempData["LoginMsg"] = "Hata";
                return RedirectToAction("Login", "Hesap");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]

        public async Task<IActionResult> CikisYap()
        {
            HttpContext.Session.Remove("User");
            HttpContext.Session.Remove("UserID");
            return RedirectToAction("GirisYap", "Hesap");
        }

        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KullaniciKayitOl(Kullanicilar user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Kullanicilar.FirstOrDefault(u => u.EPosta == user.EPosta);
                if (existingUser != null)
                {
                    TempData["RegisterMsg"] = "Bu e-posta adresi zaten kullanılıyor.";
                    return View("KayitOl");
                }
                _context.Kullanicilar.Add(user);
                _context.SaveChanges();

                return RedirectToAction("GirisYap");
            }
            else
            {
                TempData["RegisterMsg"] = "Lütfen Bilgileri Eksiksiz ve Doğru Girin!";
            }
            return View("KayitOl");
        }

    }
}
