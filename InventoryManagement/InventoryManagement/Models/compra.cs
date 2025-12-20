using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class compra
    {
        [Key]
        public int compraId { get; set; }
        public int proveedorId { get; set; }
        public string? NumeroFactura { get; set; }
        [DataType(DataType.Date)]
        public DateTime fechaCompra { get; set; }
        public string? metodoPago { get; set; }
        public string? tipoEntrega { get; set; }
        public string? transportista { get; set; }
        public string? lugarRecepcion { get; set; }
        public double costoEnvio { get; set; }
        public double subTotal { get; set; }
        public double impuesto { get; set; }
        public double descuento { get; set; }
        public double total { get; set; }
        public string? almacenDestino { get; set; }
        public string? estado { get; set; } 
        public string? motivoAnulacion { get; set; }
        public string? regionCompra { get; set; }
    }
}
