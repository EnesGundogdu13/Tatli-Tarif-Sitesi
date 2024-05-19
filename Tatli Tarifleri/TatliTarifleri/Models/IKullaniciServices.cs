using TatliTarifleri.Data;

namespace TatliTarifleri.Models
{
    public interface IKullaniciServices
    {
        int GetKullaniciID(int userId);
    }

    public class KullaniciServices : IKullaniciServices
    {
        private readonly ApplicationDbContext _context;

        public KullaniciServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetKullaniciID(int UserId)
        {
            var kullanici = _context.Kullanicilar.Find(UserId);
            return kullanici.Yetki;
        }
    }

}
