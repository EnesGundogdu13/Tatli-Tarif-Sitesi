using Microsoft.AspNetCore.Mvc;
using TatliTarifleri.Data;
using TatliTarifleri.Models;

namespace TatliTarifleri.Controllers
{
    public class TatlilarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public TatlilarController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.hostingEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            // Kategorilerin listesini al
            var kategoriler = _context.Kategoriler.ToList();

            // ViewBag'e Kategoriler listesini ekleyin
            ViewBag.Kategoriler = kategoriler;

            return View();
        }

        public IActionResult YemekEkle(TatlilarModel tatlilar)
        {
            string uniqueFileName = "";
            if (tatlilar.GorselYol != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Gorseller/Tatlilar");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + tatlilar.GorselYol.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                tatlilar.GorselYol.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            var Id = (int)HttpContext.Session.GetInt32("UserID");
            Tatlilar tatli = new Tatlilar
            {
                KullaniciId = Id,
                Isim = tatlilar.Isim,
                KategoriId = tatlilar.KategoriId,
                Malzemeler = tatlilar.Malzemeler,
                Yapilis = tatlilar.Yapilis,
                Kackisilik = tatlilar.Kackisilik,
                YapilisSuresi = tatlilar.YapilisSuresi,
                Aciklama = tatlilar.Aciklama,
                YouTubeLink = tatlilar.YouTubeLink,
                YemekGorsel = uniqueFileName
            };
            _context.Tatlilar.Add(tatli);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
