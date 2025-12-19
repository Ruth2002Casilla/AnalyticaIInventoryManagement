using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models
{
    public class salida
    {
        [Key]
        public int salidaId { get; set; }
        public int productoId { get; set; }
        public int cantidadProducto { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
        public salida()
        {
            fecha = DateTime.Now;
        }
    }
}
