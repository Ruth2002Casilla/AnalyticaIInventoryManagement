using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models
{
    public class categoria
    {
        [Key]
        public int categoriaId { get; set; }
        public string? nombreCategoria { get; set; }
        public int productoId { get; set; }
    }
}
