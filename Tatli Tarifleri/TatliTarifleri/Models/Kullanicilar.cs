using System.ComponentModel.DataAnnotations;

namespace TatliTarifleri.Models
{
    public class Kullanicilar
    {
        public int Id { get; set; }
        [Required]
        public string? EPosta { get; set; }
        [Required]
        public string? Sifre { get; set; }
        [Required]
        public string? Ad { get; set; }
        [Required]
        public int Yetki { get; set; } = 0;
    }
}
