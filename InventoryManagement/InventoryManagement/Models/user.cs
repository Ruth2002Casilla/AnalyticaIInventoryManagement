using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models
{
    public class user
    {
        [Key]
        public int userId { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }
        public string? rol { get; set; }
    }
}
