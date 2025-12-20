using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class proveedor
    {
        [Key]
        public int proveedorId { get; set; }
        public string? nombre { get; set; }
        public string? telefono { get; set; }
        public string? email { get; set; }
        public string? direccion { get; set; }
        public string? descripcion { get; set; }
        public string? RNCProveedor { get; set; }
        public DateTime llegada { get; set; }
        public DateTime retirada { get; set; }
    }
}
