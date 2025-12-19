using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class entrada
    {
        [Key]
        public int entradaId { get; set; }
        public int productoId { get; set; }
        public int cantidadProducto { get; set; }
        public int catidadCategoria { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
        public entrada()
        {
            fecha = DateTime.Now;
        }
    }
}
