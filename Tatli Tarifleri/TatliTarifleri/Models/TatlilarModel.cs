using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TatliTarifleri.Models
{
    public class TatlilarModel
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Kullanicilar")]
        public int KullaniciId { get; set; }
        public Kullanicilar Kullanicilar { get; set; }
        [Required]
        public string? Isim { get; set; }
        [Required]
        [ForeignKey("Kategoriler")]
        public int KategoriId { get; set; }
        public Kategoriler Kategoriler { get; set; }
        [Required]
        public string? Malzemeler { get; set; }
        [Required]
        public string? Yapilis { get; set; }
        [Required]
        public int Kackisilik { get; set; }
        [Required]
        public string? YapilisSuresi { get; set; }
        [Required]
        public string? Aciklama { get; set; }
        [Required]
        public string? YouTubeLink { get; set; }
        [Required]
        public string? YemekGorsel { get; set; }
        public IFormFile? GorselYol { get; set; }
        public string? GorselAdi { get; set; }
    }
}
