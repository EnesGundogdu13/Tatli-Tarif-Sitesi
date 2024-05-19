using TatliTarifleri.Data;

namespace TatliTarifleri.Models
{
    public interface ICategoryServices
    {
        IEnumerable<Kategoriler> GetKategoriler();
    }

    public class CategoryServices : ICategoryServices
    {
        private readonly ApplicationDbContext _context;

        public CategoryServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Kategoriler> GetKategoriler()
        {
            return _context.Kategoriler;
        }
    }
}
