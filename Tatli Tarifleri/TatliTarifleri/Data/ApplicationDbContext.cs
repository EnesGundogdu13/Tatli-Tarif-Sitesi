using Microsoft.EntityFrameworkCore;
using TatliTarifleri.Models;

namespace TatliTarifleri.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Tatlilar> Tatlilar { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<Kategoriler> Kategoriler { get; set; }
    }
}
