using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models
{
    public class detalleVenta
    {
        [Key]
        public int detalleVentaId { get; set; }
        public int ventaId { get; set; }
        public int productoId { get; set; }
        public double precioUnitario { get; set; }
        public double descuentoUnitario { get; set; }
        public double impuestoUnitario { get; set; }
        public double totalLinea { get; set; }
        public string? unidadMedida { get; set; }
        public string? ubicacionAlmacen { get; set; }
        public string? promocionAplicada { get; set; }
        public double margenGanancia { get; set; }
    }
}




