using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models
{
    public class detalleCompra
    {
        [Key]
        public int detalleCompraId { get; set; }
        public int compraId { get; set; }
        public int productoId { get; set; }
        public string? unidadMedida { get; set; }
        public double costoUnitario { get; set; }
        public double impuestoUnitario { get; set; }
        public double descuentoUnitario { get; set; }
        public double totalLinea { get; set; }
        public string? calidad { get; set; }
        public string? certificaciones { get; set; }
    }
}
