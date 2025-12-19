using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models
{
    public class venta
    {
        [Key]
        public int ventaId { get; set; }
        public int clienteId { get; set; }
        public string? numeroFactura { get; set; }
        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
        public string? metodoPago { get; set; }
        public string? moneda { get; set; }
        public double tasaCambio { get; set; }
        public string? canalVenta { get; set; } 
        public string? origenCampaña { get; set; } 
        public string? vendedor { get; set; }
        public double subTotal { get; set; }
        public double descuento { get; set; }
        public double impuesto { get; set; }
        public double cashback { get; set; }
        public double total { get; set; }
        public double gananciaBruta { get; set; }
        public string? cajero { get; set; }
        public string? caja { get; set; }
        public string? ubicacionAlmacen { get; set; }
        public string? usuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string? estado { get; set; } 
        public string? motivoAnulacion { get; set; }
        public string? region { get; set; }
        public string? segmento { get; set; }

    }
}


