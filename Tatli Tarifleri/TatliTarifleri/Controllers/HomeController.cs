using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TatliTarifleri.Data;
using TatliTarifleri.Models;

namespace TatliTarifleri.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int id)
        {
            if (id != 0)
            {
                IEnumerable<Tatlilar> Tatlilar = _context.Tatlilar.Where(c => c.KategoriId == id).ToList();
                return View(Tatlilar);
            }
            else
            {
                IEnumerable<Tatlilar> Tatlilar = _context.Tatlilar;
                return View(Tatlilar);
            }
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

        public IActionResult Detay(int id)
        {
            var tatli = _context.Tatlilar.Find(id);

            if (tatli != null)
            {
                var kategori = _context.Kategoriler.Find(tatli.KategoriId);
                var kullanici = _context.Kullanicilar.Find(tatli.KullaniciId);

                if (kategori != null && kullanici != null)
                {
                    var model = new TatliModel
                    {
                        tatlilar = tatli,
                        kategoriler = kategori,
                        kullanicilar = kullanici
                    };

                    return View(model);
                }
            }
            return NotFound();
        }
    }
}