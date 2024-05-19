using System.ComponentModel.DataAnnotations;

namespace TatliTarifleri.Models
{
    public class Kategoriler
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Ad { get; set; }
    }
}
