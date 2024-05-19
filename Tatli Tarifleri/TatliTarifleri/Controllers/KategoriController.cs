using Microsoft.AspNetCore.Mvc;
using TatliTarifleri.Data;
using TatliTarifleri.Models;

namespace TatliTarifleri.Controllers
{
    public class KategoriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KategoriController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var kullanici = _context.Kullanicilar.Find(HttpContext.Session.GetInt32("UserID"));
            if (kullanici != null)
            {
                if (kullanici.Yetki == 1)
                {
                    IEnumerable<Kategoriler> kategorilers = _context.Kategoriler;
                    return View(kategorilers);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Kategoriler kategoriler) 
        {
            if (ModelState.IsValid)
            {
                _context.Kategoriler.Add(kategoriler);
                _context.SaveChanges();
                TempData["SuccessMsg"] = kategoriler.Ad + " isimli kategori Eklendi!";
            }
            return RedirectToAction("Index", "Kategori");
        }

        public IActionResult Edit(int? Id)
        {
            var kategori = _context.Kategoriler.Find(Id);
            if (User == null)
            {
                return NotFound();
            }
            return View(kategori);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Kategoriler kategoriler)
        {
            if (ModelState.IsValid)
            {
                _context.Kategoriler.Update(kategoriler);
                _context.SaveChanges();
                TempData["SuccessMsg"] = kategoriler.Ad + " isimli kategori Düzenlendi!";
            }
            return RedirectToAction("Index", "Kategori");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Kategoriler? kategori = _context.Kategoriler.Find(id);

            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteCategory(Kategoriler kategoriler)
        {
            if (ModelState.IsValid)
            {
                _context.Kategoriler.Remove(kategoriler);
                _context.SaveChanges();
                TempData["SuccessMsg"] = kategoriler.Ad + " isimli kategori Silindi!";
            }
            return RedirectToAction("Index", "Kategori");
        }
    }
}
